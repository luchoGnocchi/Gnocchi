import { Component, ViewEncapsulation, OnInit, OnChanges, Input } from '@angular/core';
import { UserService } from '../../../services/user.service';

import { User } from '../../../models/User';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"
@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html'
})
export class UserViewComponent implements OnInit {

  @Input() user: User;
  constructor(private userService: UserService, private modalService: NgbModal) { }

  ngOnInit() {
  }

  open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });
  }
}
