import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, Http, Headers, JsonpModule } from '@angular/http';

import { routing } from './app.routing';

import { AppComponent }   from './app.component';
import { CustomerDetailComponent} from './customers/customer-detail.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerService } from './services/customer.service';
import { DashboardComponent } from './dashboard.component';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
// import { CustomerFormComponent} from './customers/customer-form.component';

import { WikiComponent} from './wiki/wiki.component';
import { LoginComponent } from './services/login.component';


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        JsonpModule,
        routing,
        ButtonsModule
    ],
    declarations: [
        AppComponent
        ,CustomerDetailComponent
        ,CustomersComponent
        ,DashboardComponent
        ,WikiComponent
        ,LoginComponent
        // ,CustomerFormComponent
    ],
    providers: [CustomerService, AppComponent],
    bootstrap: [AppComponent]
})

export class AppModule { }
