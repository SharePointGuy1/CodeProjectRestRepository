import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { Customer } from './customer';
import { CustomerService } from '../services/customer.service';


@Component({
  selector: 'my-customer-detail',
  styleUrls: ['app/customers/customer-detail.component.css'],
  templateUrl: 'app/customers/customer-detail.component.html'
})
export class CustomerDetailComponent implements OnInit {
  @Input()
  customer: Customer;
  errorMessage: string;

  constructor(
    private custService: CustomerService,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {

    this.route.params.forEach((params: Params) => {
      let id = +params['id'];
      this.custService.getCustomersObservableById(id)
        .subscribe(
        customer => this.customer = customer,
        error => this.errorMessage = <any>error
        );
    });
    //     .then(customer => this.customer = customer);
    // });
  }

  goBack(): void {
    window.history.back();
  }
}