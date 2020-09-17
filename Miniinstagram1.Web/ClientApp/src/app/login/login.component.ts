import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from 'ngx-auth';
import { AuthenticationService } from '../services/authentication.service';
import { FormControl } from '@angular/forms';
import { LoginModel } from '../Common/models/login.model';



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


  login(username, password) {
    var model = new LoginModel();
    model.Email = username.value;
    model.Password = password.value;
    this.authService
    .login(model)
    .subscribe(() => this.router.navigateByUrl('/'));
  }

}
