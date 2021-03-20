import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { User } from '../../_guards/_models/user';
import { UserService } from '../../_services/DatingApp/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { AuthService } from '../../_services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  /**
   *  This view child is for getting the form value
   **/
  @ViewChild('editForm') editForm: NgForm;

  /**
   * This host listener is for closing the page crossing the tab but pop up a window message
   * **/
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  user: User;

  constructor(
    private activatedRoute: ActivatedRoute,
    private authService:AuthService,
    private userService:UserService,
    private alertify: AlertifyService
  ) { }


  ngOnInit(): void {
    this.loadUser();
  }

  updateUser(): void {
    this.userService.updateUser(this.authService.decodedToken.nameId,this.user).subscribe(data=>{
      this.alertify.success('Profile Updated')
      /**
       * this.user in editForm.reset hold the current changes data in ui.
       * **/
      this.editForm.reset(this.user);
    },error => {
      this.alertify.error(error);
    })

  }

  private loadUser(): void {
    // Getting Data using Resolver
    this.activatedRoute.data.subscribe(data => {
      this.user = data['user'];
    })
  }
}
