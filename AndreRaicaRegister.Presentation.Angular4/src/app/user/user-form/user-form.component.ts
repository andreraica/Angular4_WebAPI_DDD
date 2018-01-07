import { Component, OnInit, Output, EventEmitter, TemplateRef  } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  @Output() createNewUserEvent = new EventEmitter();
  @Output() exceptionUserEvent = new EventEmitter();

  public cpfMask = [/\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/]
  userForm = new User();

  constructor(private _userService : UserService){}
    
  ngOnInit() {
  }

  create(){
    this._userService.create(this.userForm).then((res) => {
      this.createNewUserEvent.emit(res);
      this.userForm = new User();
    }).catch((ex) => {
      //MOCK Applied Service unavaliable
      this.exceptionUserEvent.emit(ex)
      this.userForm = new User();
    });
  }

}
