import { Component }        from '@angular/core';
import { Observable }       from 'rxjs/Observable';
import { WikipediaService } from './wikipedia.service';


import { Router, ActivatedRoute, Params } from '@angular/router';


@Component({
    selector: 'my-wiki',
    template: `
    <h1>Wikipedia Demo</h1>
    <p><i>Fetches after each keystroke</i></p>
    <input #term (keyup)="search(term.value)"/>
    <!--<div *ngIf="items">
        <h1>{{items}}</h1>
    </div>-->
    <ul>
      <li *ngFor="let item of items | async; let i = index">{{item}}<br /><b>{{i}}</b></li>
    </ul>
  `,
    providers: [WikipediaService]
})

export class WikiComponent {
    resp: Observable<Object[]>;
    items: Observable<string[]>;// string[];//
    // titles: string[];
    // urls: string[];

    constructor(
        private wikipediaService: WikipediaService,
        private route: ActivatedRoute
    ) { }

    search(term: string) {
        this.items = this.wikipediaService.search(term);
        // this.items = this.resp[1];// this.wikipediaService.search(term);
        // this.titles = this.resp[2]
    }
}