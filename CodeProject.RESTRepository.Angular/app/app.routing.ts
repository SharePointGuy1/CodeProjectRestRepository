import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CustomersComponent }      from './customers/customers.component';

import { CustomerDetailComponent } from './customers/customer-detail.component';
// import { CustomerFormComponent} from './customers/customer-form.component';

import { DashboardComponent } from './dashboard.component';

import { WikiComponent} from './wiki/wiki.component';
import { LoginComponent } from './services/login.component';

const appRoutes: Routes = [
    {
        path: 'detail/:id',
        component: CustomerDetailComponent
    }, {
        path: '',
        redirectTo: '/dashboard',
        pathMatch: 'full'
    }, {
        path: 'dashboard',
        component: DashboardComponent
    }, {
        path: 'customers',
        component: CustomersComponent
    }, {
        path: 'wiki',
        component: WikiComponent
    }, {
        path: 'login',
        component: LoginComponent
    }
    // ,    {
    //     path: 'custedit',
    //     component: CustomerFormComponent
    // }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
