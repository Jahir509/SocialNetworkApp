import { Component, OnInit } from '@angular/core';
import {User} from '../../_guards/_models/user';
import {UserService} from '../../_services/DatingApp/user.service';
import {AlertifyService} from '../../_services/alertify.service';
import {AuthService} from '../../_services/auth.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  user:User;

  constructor(
    private _userService:UserService,
    private _alertifyService:AlertifyService,
    private _authService:AuthService
  ) { }

  ngOnInit(): void {
    this.loadUser();
  }


  private loadUser(): void {
    this._userService.getUser(this._authService.decodedToken.nameid).subscribe((user: User) => {
      this.user = user;
      // this.galleryImages = this.getImages(this.user.photos);
    }, error => {
      this._alertifyService.error(error);
    });
  }

}
