import { Component, OnInit, ViewChild, ElementRef  } from '@angular/core';
import { HttpEventType, HttpErrorResponse } from '@angular/common/http';import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ImageServices } from  '../services/image.services';
import { ImageModel } from '../Common/models/image.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
    @ViewChild("fileUpload", {static: false}) fileUpload: ElementRef;

    constructor(private uploadService: ImageServices) { }
  ngOnInit(): void {}

public _imageModel: ImageModel = new ImageModel();

    sendFile() {
      this.uploadService.sendFormData(this._imageModel).subscribe((event: any) => {
          if (event != null) {
            console.log(event.body);
          }
        });
    }

  onClick() {
    const fileUpload = this.fileUpload.nativeElement;
    fileUpload.onchange = () => 
    {
      this._imageModel.File = fileUpload.files[0];
    };
     fileUpload.click();
  }

  onSaveClick(cat)
  {
    this._imageModel.Category = cat.value;
    this.sendFile();
  }
}