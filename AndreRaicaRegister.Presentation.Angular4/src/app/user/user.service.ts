import { Injectable } from '@angular/core';
import { User } from './user';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/catch';
import { Globals } from '../globals';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserService {

  constructor(
    private _http: HttpClient,
    private globals: Globals
  ) { }

  create(user: User){
    return this._http.post<User>(this.globals.urlAPI + "/Users", user);
  }

  getUsers(): Observable<User[]> {
    return this._http.get<User[]>(this.globals.urlAPI + "/Users");
  }
  
  private handleErrorPromise (error: Response | any) {
    console.error(error.message || error);
    return Promise.reject(error.message || error);
  }	

}
