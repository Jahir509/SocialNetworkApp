import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  values:any=[];

  constructor(private http:HttpClient) {}

  ngOnInit(): void {
    this.getValues();
  }

  private getValues(): void {
    this.http.get('https://localhost:44340/Values').subscribe(data=>this.values=data);
  }
}
