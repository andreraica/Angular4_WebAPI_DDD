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

  public modalRef: BsModalRef;
  userForm = new User();

  constructor(
    private _userService : UserService,
    private modalService: BsModalService) { }

  ngOnInit() {
  }
  
  public openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template); // {3}
  }

  create(){
    this._userService.create(this.userForm).then((res) => {
      this.createNewUserEvent.emit(res);
      this.userForm = new User();
    });
  }

}
