import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { Token } from '../auth/token';
import { AuthUser } from '../auth/auth-user';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  constructor(
    private router: Router,
    private _authService: AuthService
  ) { }

  authUser = new AuthUser();
  
  ngOnInit() {
  }

  loginUser(){
    //e.preventDefault();
    //e.target.element[0].value

    this._authService.authenticate(this.authUser)
    .subscribe((token:Token) => {
      localStorage.setItem('access_token', token.access_token)
      this.router.navigate(['/user']);
    })

  }
}
