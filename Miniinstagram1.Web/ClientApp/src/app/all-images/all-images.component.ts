import { Component, OnInit } from '@angular/core';
import { ImageServices } from '../services/image.services';

@Component({
  selector: 'app-all-images',
  templateUrl: './all-images.component.html',
  styleUrls: ['./all-images.component.css']
})
export class AllImagesComponent implements OnInit {

  constructor(private _imageServices: ImageServices) { }

  public teams = [];

  public teest;

  ngOnInit(): void {
  }

}
