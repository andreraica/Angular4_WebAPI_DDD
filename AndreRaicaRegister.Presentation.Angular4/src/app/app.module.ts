import { AppBootstrapModule } from './appBootstrap.module';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { UserFormComponent } from './user/user-form/user-form.component';
import { UserListComponent } from './user/user-list/user-list.component';

import { UserService } from './user/user.service';

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
    AppBootstrapModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
