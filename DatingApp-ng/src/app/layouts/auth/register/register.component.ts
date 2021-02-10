import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model:any = {};
  @Output() cancelRegister = new EventEmitter();
  constructor(
    private http:HttpClient,
    private _authService:AuthService
  ) { }

  ngOnInit(): void {
  }

  register(){
    this._authService.register(this.model).subscribe(()=>{
      console.log("Registered Successfully")
    },error => {
        console.log('failed to register')
    });
  }

  cancel(){
    this.cancelRegister.emit(false);
    console.log('cancel clicked');
  }

}
