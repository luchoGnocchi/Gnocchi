import { Component, ViewEncapsulation, OnInit, OnChanges, Input } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { MessageManagerService } from '../../../services/message-manager.service';
import { User } from '../../../models/User';
import {   Rol } from '../../../models/Rol';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
})
export class UserEditComponent implements OnInit {
  @Input() user: User;
  constructor(private userService: UserService, private modalService: NgbModal, private menssage: MessageManagerService) { }

  ngOnInit() {
  }
  update() {
    console.log(this.user);
    this.userService.update(this.user).subscribe(
      data => { this.menssage.success(data.text()) },
      error => { this.menssage.error(error._body); });
  }
  open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });
  }

}
