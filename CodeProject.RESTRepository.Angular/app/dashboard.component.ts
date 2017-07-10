import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Customer } from './customers/customer';
import { CustomerService } from './services/customer.service';

@Component({
  selector: 'my-dashboard',
  templateUrl: 'app/dashboard.component.html',
  styleUrls: ['app/dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  customers: Customer[] = [];
  errorMessage: string;

  constructor(
    private router: Router,
    private customerService: CustomerService
  ) { }

  ngOnInit(): void {
    // this.customerService.getCustomers()
    //   .then(customers =>
    //     this.customers = customers.slice(0, 4));
    this.customerService.getCustomersObservable()
      .subscribe(
      customers => this.customers = customers,
      error => { 
        this.errorMessage = <any>error; 
      }
      );
  }

  gotoDetail(cust: Customer): void {
    let link = ['/detail', cust.customerId];
    this.router.navigate(link);
  }

}