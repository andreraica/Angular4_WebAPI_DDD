import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { Token } from '../auth/token';

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

  ngOnInit() {
  }

  loginUser(e){
    e.preventDefault();
    //e.target.element[0].value

    this._authService.authenticate('admin','admin')
    .subscribe((token:Token) => {
      localStorage.setItem('access_token', token.access_token)
      this.router.navigate(['/user']);
    })

  }
}
