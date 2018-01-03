import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  @Input() users;
  //@Output() getUsersEvent = new EventEmitter();
  
  constructor(private _userService: UserService) { }

  ngOnInit() {
  }

  //getUsers(){
  //  this._userService.getUsers();
  //}

}
