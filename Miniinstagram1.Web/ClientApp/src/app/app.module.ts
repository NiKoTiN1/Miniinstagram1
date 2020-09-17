import { BrowserModule } from '@angular/platform-browser';
import { AuthenticationModule } from '../app/authentication/authentication.module';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AuthenticationService } from './services/authentication.service';

import { HomeComponent } from './home/home.component';
import { AppComponent } from './app.component';
import { LogoutComponent } from './logout/logout.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

import { PublicGuard, ProtectedGuard } from 'ngx-auth';
import { AllImagesComponent } from './all-images/all-images.component';

import { MatCardModule } from '@angular/material/card';



export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AuthenticationModule,
    ReactiveFormsModule,
    MatCardModule ,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate: [ ProtectedGuard ] },
      { path: 'login', component: LoginComponent, canActivate: [ PublicGuard ] },
      { path: 'registration', component: RegistrationComponent, canActivate: [ PublicGuard ] },
  ])],
  declarations: [ 
    AppComponent,
    HomeComponent,
    LogoutComponent,
    RegistrationComponent,
    LoginComponent,
    AllImagesComponent,
  ],

  providers: [
    AuthenticationService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
