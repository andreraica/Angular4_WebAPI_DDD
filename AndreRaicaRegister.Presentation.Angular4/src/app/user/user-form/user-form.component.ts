import { Component, OnInit, Output, EventEmitter  } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  @Output() createNewUserEvent = new EventEmitter();

  userForm = new User();

  constructor(private _userService : UserService) { }

  ngOnInit() {
  }

  create(){
    this._userService.create(this.userForm);
    this.createNewUserEvent.emit(this.userForm);
    this.userForm = new User();
  }

}
