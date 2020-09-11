import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, map, switchMap, catchError } from 'rxjs/operators';
import { AuthService } from 'ngx-auth';

 import { TokenStorage } from './token-storage.service';

interface AccessData {
  token: string;
}

@Injectable()
export class AuthenticationService implements AuthService {

  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorage
  ) {}

  public isAuthorized(): Observable < boolean > {
    return this.tokenStorage
      .getAccessToken()
      .pipe(map(token => !!token));
  }

  public getAccessToken(): Observable < string > {
    return this.tokenStorage.getAccessToken();
  }

  public refreshToken(): Observable <AccessData> {
    return this.tokenStorage
      .getRefreshToken()
      .pipe(
        switchMap((refreshToken: string) =>
          this.http.post(`http://localhost:3000/refresh`, { refreshToken })
        ),
        tap((tokens: AccessData) => this.saveAccessData(tokens)),
        catchError((err) => {
          this.logout();

          return Observable.throw(err);
        })
      );
  }

  public refreshShouldHappen(response: HttpErrorResponse): boolean {
    return response.status === 401
  }

  public verifyTokenRequest(url: string): boolean {
    return url.endsWith('/refresh');
  }

  public login(email:string, password:string): Observable<any> {
    const formData = new FormData()
    formData.append('Email', email)
    formData.append('Password', password)

    return this.http.post(`https://localhost:5001/api/account/login`, formData)
    .pipe(tap((token: AccessData) => this.saveAccessData(token)));
  }

  public logout(): void {
    this.tokenStorage.clear();
    location.reload(true);
  }

  public registration(email:string, password:string) {
    const formData = new FormData()
    formData.append('Email', email)
    formData.append('Password', password)
    formData.append('PasswordConfirm', password)

    return this.http.post(`https://localhost:5001/api/account/register`, formData)
  }

  private saveAccessData({ token }: AccessData) {
    this.tokenStorage
      .setAccessToken(token)
  }
}