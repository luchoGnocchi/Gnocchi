import { Component, ViewEncapsulation, OnInit, OnChanges, Input } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { MessageManagerService } from '../../../services/message-manager.service';
import { User } from '../../../models/User';
import {  Rol } from '../../../models/Rol';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms";

import { Router } from '@angular/router';
@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html'
})
export class UserCreateComponent implements OnInit {
  user: User = new User();
  constructor(private userService: UserService, private modalService: NgbModal, private router: Router, private menssage: MessageManagerService) { }

  ngOnInit() {

    this.user = new User();
    this.user.Rol = new Rol();
  }
  register() {
    this.userService.create(this.user).subscribe(
      data => {
        this.menssage.success(data.text()),
        //  this.moveToUsers();
        this.userService.getUsers();
      },
      error => { this.menssage.error(error._body); }
    );
  }
  open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });

  }
  moveToUsers() {
    this.router.navigate(['/users']);
  }
}
