import { AppBootstrapModule } from './appBootstrap.module';
import { TextMaskModule } from 'angular2-text-mask';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { UserFormComponent } from './user/user-form/user-form.component';
import { UserListComponent } from './user/user-list/user-list.component';

import { TokenInterceptor } from './auth/token.interceptor';
import { UserService } from './user/user.service';
import { Globals } from './globals';
import { AuthService } from './auth/auth.service';
import { LoginFormComponent } from './login-form/login-form.component';
import { JwtInterceptor } from './auth/jwt.interceptor';

const appRoutes:Routes = [
  {
    path: '',
    component: LoginFormComponent
  },
  {
    path: 'user',
    component: UserComponent
  }
]

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    UserFormComponent,
    UserListComponent,
    LoginFormComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    FormsModule,
    AppBootstrapModule,
    TextMaskModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    AuthService,
    UserService, 
    Globals
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
