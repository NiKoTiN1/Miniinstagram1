  
import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';

@Component({
    selector: 'app',
    template: `
    <app-all-images></app-all-images>`
    // template: `
    // <app-logout></app-logout>
    // <app-all-images></app-all-images>
    // <router-outlet></router-outlet>`
})
export class AppComponent {
    name = '';
}