import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth.service';
import { AlertifyService } from '../../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};

  constructor(
    public _authService: AuthService,
    private alertify:AlertifyService,
    private router:Router
  ) { }

  ngOnInit(): void {
  }

  login() {
    this._authService.login(this.model).subscribe((data) => {
        this.alertify.success(('logged in service'))
      },
      error => {
       this.alertify.error(error)
      }, ()=>{
        this.router.navigate(['/members']);
      });
  }

  loggedIn(){
    return this._authService.loggedIn();
  }

  logout(){
    localStorage.removeItem('token');
    this.alertify.message('Logged out');
    this.router.navigate(['/home']);
  }

}
