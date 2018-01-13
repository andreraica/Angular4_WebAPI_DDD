import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Globals } from '../globals';
import { Observable } from 'rxjs/Observable';
import { AuthUser } from './auth-user';
//import decode from 'jwt-decode';

@Injectable()
export class AuthService {

  constructor(
    private _http:HttpClient,
    private globals: Globals
  ) {}

  public isAuthenticated(): boolean {
    // get the token
    //const token = localStorage.getItem('access_token');
    // return a boolean reflecting 
    // whether or not the token is expired
    return true; //tokenNotExpired(null, token);
  }

  public authenticate(user: string, pass: string) {
    
    // let authUser = new URLSearchParams();
    // authUser.set('grant_type', 'password');
    // authUser.set('username', user);
    // authUser.set('password', pass);
    // authUser.set('client_id', 'client');
    // authUser.set('client_secret', 'secret');
    
    // let authUser = new HttpParams()
    // .set('grant_type', 'password')
    // .set('username', user)
    // .set('password', pass)
    // .set('client_id', 'client')
    // .set('client_secret', 'secret');

    let authUser = new AuthUser();
    authUser.grant_type = 'password';
    authUser.username = user;
    authUser.password = pass;
    authUser.client_id = 'client';
    authUser.client_secret = 'secret';

    // let grant_type = 'password';
    // let username = user;
    // let password = pass;
    // let client_id = 'client';
    // let client_secret = 'secret';
    // let authUser = "grant_type=password&username=" + username + "&password=" + password + "&client_id=" + client_id + "&client_secret=" + client_secret + "&crossDomain=true";


    let header = new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded;charset=utf-8;');

    this._http.post<string>(this.globals.urlToken + "/Token", authUser, { headers: header })
    .subscribe((token:string) => {
      localStorage.setItem('access_token', token)
    });
     
  }

}