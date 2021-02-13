import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  jwtHelper = new JwtHelperService()

  constructor(private http:HttpClient,private _authService: AuthService) {}

  ngOnInit(): void {
    // fetch token from localstorage
    const token  = localStorage.getItem('token');
    if(token){
      // set token values globally for user using token
      this._authService.decodedToken = this.jwtHelper.decodeToken(token);
    }

  }
}
