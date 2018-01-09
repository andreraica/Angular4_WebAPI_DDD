import { AppBootstrapModule } from './appBootstrap.module';
import { TextMaskModule } from 'angular2-text-mask';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { UserFormComponent } from './user/user-form/user-form.component';
import { UserListComponent } from './user/user-list/user-list.component';

import { TokenInterceptor } from './auth/token.interceptor';
import { UserService } from './user/user.service';
import { Globals } from './globals';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    UserFormComponent,
    UserListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppBootstrapModule,
    TextMaskModule,
    HttpClientModule
  ],
  providers: [
    TokenInterceptor,
    UserService, 
    Globals
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
