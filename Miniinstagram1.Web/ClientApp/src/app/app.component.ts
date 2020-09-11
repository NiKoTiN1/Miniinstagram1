  
import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';

@Component({
    selector: 'app',
    template: `
    <app-logout></app-logout>
    <router-outlet></router-outlet>`
})
export class AppComponent {
    name = '';
}