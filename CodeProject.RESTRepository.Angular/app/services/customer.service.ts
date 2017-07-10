import {Component, Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { OnInit} from '@angular/core';


import 'rxjs/add/operator/toPromise';
import { Observable } from 'rxjs/observable';

import { AppComponent } from '../app.component';

// import { jquery } from 'jquery/dist/jquery';

import { Customer } from '../customers/customer';
// solely for the mock services
// import { CUSTOMERS } from '../customers/mock-customers';

@Component({
    providers: [AppComponent]
})

@Injectable()
export class CustomerService implements OnInit {

    private customersUrl = 'http://localhost:5000/api/customers';
    private headers = new Headers({ 'Content-Type': 'application/json' });

    private apiUrl: string;

    constructor(
        private http: Http,
        private appComponent: AppComponent
    ) { }

    ngOnInit(): void {
        this.apiUrl = this.appComponent.apiUrl;
    }

    getCustomersObservable(): Observable<Customer[]> {
        return this.http.get(this.customersUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getCustomersObservableById(id: number): Observable<Customer> {
        return this.http.get(this.customersUrl + '/' + id)
            .map(this.extractData)
            .catch(this.handleError);
    }

    // getCustomers(): Promise<Customer[]> {
    //     return Promise.resolve(CUSTOMERS);
    // }

    getCustomersHttpPromise(): Promise<Customer[]> {
        return this.http.get(this.customersUrl)
            .toPromise()
            .then(this.extractData) //(response => response.json().data as Customer[])
            .catch(this.handlePromiseError);
    }

    // getCustomersSlowly(): Promise<Customer[]> {
    //     return new Promise<Customer[]>(resolve =>
    //         setTimeout(resolve, 2000)) // delay 2 seconds
    //         .then(() => this.getCustomers());
    // }

    // getCustomersNoPromise(): Customer[] {
    //     return CUSTOMERS;
    // }

    getCustomer(id: number): Promise<Customer> {
        return this.getCustomersHttpPromise()
            .then(customers => customers.find(customer => customer.customerId === id));
    }

    addCustomer(customerName: string): Observable<Customer> {
        let body = JSON.stringify({ customerName });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.customersUrl, body, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    update(customer: Customer): Promise<Customer> {
        const url = `${this.customersUrl}/${customer.customerId}`;
        return this.http
            .put(url, JSON.stringify(customer), { headers: this.headers })
            .toPromise()
            .then(() => customer)
            .catch(this.handleError);
    }

    // private/helper methods
    private extractData(res: Response) {
        let body = res.json();
        // return body.data || {};
        // json is in body with no data object
        return body || {};
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

    private handlePromiseError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Promise.reject(errMsg);
    }
    // end private/helper methods
}

