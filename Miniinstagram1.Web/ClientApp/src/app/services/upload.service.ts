import { HttpClient, HttpEvent, HttpErrorResponse, HttpEventType } from  '@angular/common/http';
import { map } from  'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UploadService {  
  serverUrl: string = "https://localhost:5001/api/uploadfile/add";
  constructor(private httpClient: HttpClient) { }
  public sendFormData(formData) {
    return this.httpClient.post<any>(this.serverUrl, formData);
  }
}