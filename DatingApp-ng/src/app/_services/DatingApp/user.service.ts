import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../../_guards/_models/user';

// This is for getting the information of token for validation on the url
// const httpOptions = {
//   headers: new HttpHeaders({
//     'Authorization':'Bearer '+localStorage.getItem('token')
//   })
// }

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  getUsers():Observable<User[]>{
    return this.http.get<User[]>(this.baseUrl+ 'user');
    // return this.http.get<User[]>(this.baseUrl+ 'user',httpOptions);
  }
  getUser(id:number):Observable<User>{
    return this.http.get<User>(this.baseUrl+ 'user/'+id);
    // return this.http.get<User>(this.baseUrl+ 'user/'+id,httpOptions);
  }

  updateUser(id:number,user:User){
    return this.http.put(this.baseUrl +'users/'+ id, user);
  }
}
