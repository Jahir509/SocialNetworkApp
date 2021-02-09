import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};

  constructor(private _authService: AuthService) { }

  ngOnInit(): void {
  }

  login() {
    this._authService.login(this.model).subscribe((data) => {
        console.log(('logged in service'))
      },
      error => {
        console.log('failed to login')
      });
  }

  loggedIn(){
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout(){
    localStorage.removeItem('token');
    console.log('Logged out');
  }

}
