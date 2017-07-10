import { Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import './rxjs-operators';

import { Customer } from './customers/customer';
import { CustomerService } from './services/customer.service';

@Component({
  selector: 'wwi-app',
  styleUrls: ['app/app.component.css'],
  template: `
    <h1>{{title}}</h1>
    <nav>
      <a routerLink="/dashboard" routerLinkActive="active">Dashboard</a>
      <a routerLink="/customers" routerLinkActive="active">Customers</a>
      <a routerLink="/wiki" routerLinkActive="active">Wiki Search</a>
      <a routerLink="/login" routerLinkActive="active">Login</a>
     <a routerLink="/custedit" routerLinkActive="active">Customer Add/Edit</a> 
    </nav>
    <router-outlet></router-outlet>
    <!--<our-customers></our-customers>-->
    `,
  styles: [],
  providers: []
})

export class AppComponent {
  title = 'World Wide Importers';
  public apiUrl: string = 'http://localhost:5000';
}
