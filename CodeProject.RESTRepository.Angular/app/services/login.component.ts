import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormBuilder, Validators, NgControl, FormGroup, NgForm } from '@angular/forms';
// import './rxjs-operators';


import { LoggerService }    from '../services/logger.service';

@Component({
    selector: 'login-form',
    templateUrl: 'app/services/login.component.html'
})

export class LoginComponent implements OnInit {

    private loginForm: FormGroup;
    // private emailCtrl: NgControl;
    // private pwordCtrl: NgControl;

    constructor(
        // fb: FormBuilder,
        private route: ActivatedRoute
    ) {
        // this.loginForm = fb.group({
        //     email: ["", Validators.required],
        //     password: ["", Validators.required]
        // });
    }

    ngOnInit(): void {
    }

    doLogin(event) {
        // console.log(this.loginForm.value);
        event.preventDefault();
    }

}