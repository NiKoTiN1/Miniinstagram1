import { Component, OnInit, ViewChild, ElementRef  } from '@angular/core';
import { HttpEventType, HttpErrorResponse } from '@angular/common/http';import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { UploadService } from  '../services/upload.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
    @ViewChild("fileUpload", {static: false}) fileUpload: ElementRef;

    files  = [];
    constructor(private uploadService: UploadService) { }
  ngOnInit(): void {}

    sendFile(file, category) {
      const formData = new FormData();
      formData.append('file', file.data);
      formData.append('category', category);
      file.inProgress = true;
      this.uploadService.sendFormData(formData).subscribe((event: any) => {
          if (typeof (event) === 'object') {
            console.log(event.body);
          }
        });
    }

    private sendFiles(category) {
      this.fileUpload.nativeElement.value = '';
      this.files.forEach(file => {
        this.sendFile(file, category);
      });
  }

  onClick() {
    const fileUpload = this.fileUpload.nativeElement;fileUpload.onchange = () => 
    {
      for (let index = 0; index < fileUpload.files.length; index++)
      {
        const file = fileUpload.files[index];
        this.files.push({ data: file, inProgress: false, progress: 0});
      }
    };
     fileUpload.click();
  }

  onSaveClick(cat)
  {
    this.fileUpload
    this.sendFiles(cat.value);
  }
}