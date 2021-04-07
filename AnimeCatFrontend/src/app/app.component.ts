import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit
{
  title = 'The Dating App';
  animes: any

  constructor(private http: HttpClient) {}

  ngOnInit()
  {
    this.getUsers();
  } 

  getUsers()
  {
    this.http.get('https://localhost:44395/api/animes').subscribe(response =>
    {
      this.animes = response;
    } ,
    error =>
    {
      console.log(error);
    });
  }
}
