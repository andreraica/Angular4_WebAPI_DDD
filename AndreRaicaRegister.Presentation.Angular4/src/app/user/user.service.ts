import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { User } from './user';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/catch';


@Injectable()
export class UserService {

  constructor(private _http: Http) { }

  create(user: User){
    return this._http.post("http://localhost:63324/api/Users", user)
    .map(data => data.json())
    .catch(err => Observable.throw(err.json().error || 'Server error / unavaliable'))
    .toPromise();
  }

  getUsers(){
    return this._http.get("http://localhost:63324/api/Users")
    .map(data => data.json())
    .catch(err => Observable.throw(err.json().error || 'Server error / unavaliable'))
    .toPromise();
  }

}
