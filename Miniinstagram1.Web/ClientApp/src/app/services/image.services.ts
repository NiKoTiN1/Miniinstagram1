import { HttpClient, HttpEvent, HttpErrorResponse, HttpEventType } from  '@angular/common/http';
import { map } from  'rxjs/operators';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ImageModel } from '../Common/models/image.model';


@Injectable({
  providedIn: 'root'
})
export class ImageServices {  
  serverUrl: string = environment.upplaodFileUrl;
  constructor(private httpClient: HttpClient) { }
  public sendFormData(imageData:ImageModel) {
    const formData = new FormData();
    formData.append("file", imageData.File);
    formData.append("category", imageData.Category);
    return this.httpClient.post<any>(this.serverUrl, formData);
  }
}