import { Component, OnInit, OnChanges, OnDestroy, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from "@angular/forms";
import { UserService } from "../../services/user.service";
import { ConfigurationService } from "../../app.configuration.service";
import { User } from "../../models/User";
import { Rol } from "../../models/Rol";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  password: string = "";
  username: string = "";


  errorMessage: string = " ";
  constructor(private router: Router, private userService: UserService, private configurationService: ConfigurationService) { }

  ngOnInit() {
  }
  moveToHome() {

    this.userService.getUserByToken()
      .subscribe(user => {
        localStorage.setItem('Rol', user.Rol_Id + "");
        localStorage.setItem('Token', user.Token);
        localStorage.setItem('IdUser', user.Id + "");

      });
    this.configurationService.blnDisplayMenu = true;
    this.router.navigate(["/vehicle"]);
    setTimeout(function () { window.location.href = "_"; }, 1000);
  }


  login() {


    this.userService.getToken(this.username, this.password)
      .subscribe(
      data =>
        this.moveToHome(),
      error => {
        this.errorMessage = error._body,
          console.log(error);
      }
      );
    if (this.userService.isLogged()) {
      this.moveToHome();
    }
  }
}
