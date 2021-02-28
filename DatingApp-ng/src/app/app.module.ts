import { NgModule } from '@angular/core';
import { BrowserModule, HAMMER_GESTURE_CONFIG } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './layouts/navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { RegisterComponent } from './layouts/auth/register/register.component';
import { HomeComponent } from './home/home.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MemberListComponent } from './member-list/member-list.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { MemberCardComponent } from './member-list/member-card/member-card.component';
import { JwtModule } from '@auth0/angular-jwt';
import { MemberComponent } from './member-list/member/member.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';


export function tokenGetter(){
  return localStorage.getItem('token')
}

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    RegisterComponent,
    HomeComponent,
    MemberListComponent,
    ListsComponent,
    MessagesComponent,
    MemberCardComponent,
    MemberComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    TabsModule.forRoot(),
    NgxGalleryModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44340"],
        disallowedRoutes: ["localhost:44340/api/auth"],
      },
    }),
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
