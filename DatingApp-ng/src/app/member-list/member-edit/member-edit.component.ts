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
  user: User;

  constructor(
    private activatedRoute: ActivatedRoute,
    private alertify: AlertifyService
  ) { }

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  ngOnInit(): void {
    this.loadUser();
  }

  updateUser(): void {
    console.log(this.user);
    this.alertify.success('Profile Updated')
    this.editForm.reset(this.user);
  }

  private loadUser(): void {
    // Getting Data using Resolver
    this.activatedRoute.data.subscribe(data => {
      this.user = data['user'];
    })
  }
}
