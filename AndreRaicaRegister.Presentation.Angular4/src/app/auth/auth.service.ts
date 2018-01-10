import { Injectable } from '@angular/core';
//import decode from 'jwt-decode';

@Injectable()
export class AuthService {
  public getToken(): string {
    return '123456ABC'; //localStorage.getItem('access_token');
  }
  public isAuthenticated(): boolean {
    // get the token
    const token = this.getToken();
    // return a boolean reflecting 
    // whether or not the token is expired
    return true; //tokenNotExpired(null, token);
  }
}