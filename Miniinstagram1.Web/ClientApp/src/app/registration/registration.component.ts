import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(private http: HttpClient, private router: Router, private authService: AuthenticationService) { }

  ngOnInit(): void {
  }

  invalidLogin: boolean

  username = new FormControl('');
  password = new FormControl('');


  register() {
    this.authService
    .registration(this.username.value, this.password.value)
    .subscribe(() => this.router.navigateByUrl('/login'));
  }

}
