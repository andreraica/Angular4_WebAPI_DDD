import { Component, OnInit } from '@angular/core';
import { User } from './user';
import { UserService } from './user.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: Array<User> = [];

  constructor(
    private _userService : UserService,
    private modalService: BsModalService) { 

    }

  ngOnInit() {
    this.getUsers();
  }

  createUser(user: User){
    this.users.push(user);
  }

  getUsers(){
    this._userService.getUsers().subscribe
    ((users: Array<User>) => {
      this.users = users;
    });

  }

  exceptionUser(ex){
    //this.modalService.show(ex); // {3}
    alert(ex);
  }

}
