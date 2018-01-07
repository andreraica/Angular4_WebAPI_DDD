import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { User } from './user';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/catch';
import { Globals } from '../globals';

@Injectable()
export class UserService {

  constructor(
    private _http: Http,
    private globals: Globals
  ) { }

  create(user: User){
    return this._http.post(this.globals.urlAPI + "/Users", user)
    .map(data => data.json())
    .catch(this.handleErrorPromise)
    .toPromise();
  }

  getUsers(): Promise<User[]> {
    return this._http.get(this.globals.urlAPI + "/Users")
    .map(data => data.json())
    .catch(this.handleErrorPromise)
    .toPromise();
  }
  
  private handleErrorPromise (error: Response | any) {
    console.error(error.message || error);
    return Promise.reject(error.message || error);
  }	

}
