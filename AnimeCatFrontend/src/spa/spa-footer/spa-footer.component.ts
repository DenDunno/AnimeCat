import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'spa-footer',
  templateUrl: './spa-footer.component.html',
  styleUrls: ['./spa-footer.component.css']
})
export class SpaFooterComponent implements OnInit {
title = 'All right reserved';
year = new Date().getUTCFullYear();

  constructor() { }

  ngOnInit(): void {
  }

}
