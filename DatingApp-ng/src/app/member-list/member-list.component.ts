import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services/DatingApp/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { User } from '../_guards/_models/user';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  userList: User[];

  constructor(
    private _userService:UserService,
    private alertify: AlertifyService
  ) { }

  ngOnInit(): void {
    this.loadUser();

  }

private loadUser(): void {
  this._userService.getUsers().subscribe((data:User[])=>{
    this.userList = data
  }, error => {
    this.alertify.error(error);
  });
}

}
