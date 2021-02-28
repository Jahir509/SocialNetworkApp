import { Component, OnInit } from '@angular/core';
import { User } from '../../_guards/_models/user';
import { UserService } from '../../_services/DatingApp/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { Photo } from '../../_guards/_models/photo';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';


@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css']
})
export class MemberComponent implements OnInit {

  user:User;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(
    private _userService:UserService,
    private _alertifyService:AlertifyService,
    private route:ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadUser();
    this.galleryOptions = [{
      width: '500px',
      height: '500px',
      imagePercent: 100,
      imageAnimation: NgxGalleryAnimation.Slide,
      preview:false
    }];
    this.galleryImages = [];

  }

  private loadUser(): void {
    this._userService.getUser(+this.route.snapshot.params['id']).subscribe((user:User)=>{
      this.user = user;
      this.galleryImages = this.getImages(this.user.photos);
    },error=>{
      this._alertifyService.error(error);
    });

  }

   getImages(photos: Photo[]) {
    let imageUrls = [];
    for(const photo of photos){
      imageUrls.push({
        small: photo.url,
        medium: photo.url,
        big: photo.url,
        description:photo.description
      });
    }
    return imageUrls;
  }
}
