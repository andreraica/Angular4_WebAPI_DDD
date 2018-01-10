import { Component, OnInit, Output, EventEmitter, TemplateRef  } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Globals } from '../../globals';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  @Output() createNewUserEvent = new EventEmitter();
  @Output() exceptionUserEvent = new EventEmitter();

  userForm = new User();

  constructor(
    private _userService : UserService,
    private globals: Globals){}
    
  ngOnInit() {
  }

  create(){
    this._userService.create(this.userForm).subscribe
    ((res: User) => {
      this.createNewUserEvent.emit(res);
    }, (error) => {
      this.exceptionUserEvent.emit(error)
    }, () => {
      this.userForm = new User();
    });
  }

}
