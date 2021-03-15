import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { MemberListComponent } from './member-list/member-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberComponent } from './member-list/member/member.component';
import { MemberEditComponent } from './member-list/member-edit/member-edit.component';
import { MemberEditResolver } from './member-list/member-edit/member-edit.resolver';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

export const appRoutes: Routes = [
  {path: '', component: HomeComponent},

  {
    path: '',
    runGuardsAndResolvers: 'always',              // this 2 following lines is for authentication guard
    canActivate: [AuthGuard],
    children: [
      {path: 'members', component: MemberListComponent},
      {path: 'members/:id', component: MemberComponent},
      {path: 'member/edit', component: MemberEditComponent, resolve: {user: MemberEditResolver}, canDeactivate:[PreventUnsavedChangesGuard]},
      {path: 'messages', component: MessagesComponent},
      {path: 'lists', component: ListsComponent},
    ]
  },
  {path: '**', redirectTo: '', pathMatch: 'full'},
];
