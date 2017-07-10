import { Component } from '@angular/core';
import { Customer }    from './customer';

@Component({
    selector: 'customer-form',
    templateUrl: 'customer-form.component.html'
})

export class CustomerFormComponent {

    submitted: boolean = false;

    onSubmit() {
        this.submitted = true;
    }

    // Reset the form with a new customer AND restore 'pristine' class state
    // by toggling 'active' flag which causes the form
    // to be removed/re-added in a tick via NgIf
    // TODO: Workaround until NgForm has a reset method (#6822)
    active = true;
}
