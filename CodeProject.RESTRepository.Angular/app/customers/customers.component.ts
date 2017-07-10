import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
// import './rxjs-operators';


import { LoggerService }    from '../services/logger.service';


import { Customer } from '../customers/customer';
import { CustomerService } from '../services/customer.service';


@Component({
  selector: 'our-customers',
  templateUrl: 'app/customers/customers.component.html',
  styleUrls: ['app/customers/customers.component.css'],
  providers: [CustomerService, LoggerService]
})

export class CustomersComponent implements OnInit, OnDestroy {
  title = 'World Wide Importers Customers';
  customers: Customer[];
  selectedCustomer: Customer;
  errorMessage: string;
  mode = 'Observable';

  constructor(
    private customerService: CustomerService,
    private router: Router,
    private route: ActivatedRoute,
    private logger: LoggerService
  ) { }

  ngOnInit(): void {
    // console.log("OnInit start");
    this.getCustomers();
    // console.log("OnInit end");
  }

  ngOnDestroy(): void {
    // console.log("OnDestroy");
  }

  getCustomers() {

    // get params
    this.route.params.forEach((params: Params) => {
      let pageSize = +params['pageSize'];
      let pageNumber = +params['pageNumber'];

      this.customerService.getCustomersObservable()
        .subscribe(
        customers => this.customers = customers,
        error => this.errorMessage = <any>error
        );
    });
    // this.customerService.getCustomers().then(customers => this.customers = customers);
    // this.customerService.getCustomersHttpPromise()
    //   .then(customers => this.customers = customers,
    //   error => this.errorMessage = <any>error
    //   );
  }

  addCustomer(name: string) {
    if (!name) { return; }
    this.customerService.addCustomer(name)
      .subscribe(
      hero => this.customers.push(hero),
      error => this.errorMessage = <any>error);
  }

  onSelect(customer: Customer): void {
    this.selectedCustomer = customer;
  }

  gotoDetail(): void {
    this.router.navigate(['/detail', this.selectedCustomer.customerId]);
  }

  protected logIt(msg: string) {
    this.logger.log(msg);
  }
}
