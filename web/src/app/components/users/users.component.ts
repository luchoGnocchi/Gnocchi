import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/User';
@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit {
  pageTitle: string = "Lista de usuarios";
  users: Array<User>;
  errorMessage: string;
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUsers()
      .subscribe(vehiclesObtained => this.users = vehiclesObtained,
      error => this.errorMessage = <any>error);
  }

  verVehicle(id: number) {

  }

}
