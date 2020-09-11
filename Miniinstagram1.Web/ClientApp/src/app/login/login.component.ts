import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from 'ngx-auth';
import { AuthenticationService } from '../services/authentication.service';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private http: HttpClient, private router: Router, private authService: AuthenticationService) { }

  ngOnInit(): void {
  }

  invalidLogin: boolean

  username = new FormControl('');
  password = new FormControl('');


  login() {
    this.authService
    .login(this.username.value, this.password.value)
    .subscribe(() => this.router.navigateByUrl('/'));
  }

}
