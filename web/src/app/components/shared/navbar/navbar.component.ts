import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../../app.configuration.service';
import { UserService } from '../../../services/user.service';
import { VehicleService } from '../../../services/vehicle.service';
import { User } from '../../../models/User';
import { Vehicle } from '../../../models/Vehicle';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { MessageManagerService } from '../../../services/message-manager.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent implements OnInit {
  rol: number;
  blnDisplayMenu: boolean;
  VIN: string = ""
  Vehicle: Vehicle;
  constructor(private router: Router, private userservice: UserService, private configurationService: ConfigurationService, private vehicleService: VehicleService, private menssage: MessageManagerService) {
    if (localStorage.getItem('Rol') == 'null') {
      this.router.navigate(["/login"]);
    }
  }

  ngOnInit() {

  }
  logout() {
    localStorage.setItem('Rol', 'null');
    localStorage.setItem('Token', 'null');
    localStorage.setItem('IdUser', 'null');
    this.userservice.clearCokis();
    this.router.navigate(["/login"]);
  }

  ngDoCheck() {
    this.blnDisplayMenu = localStorage.getItem('Rol') != 'null';
    if (this.blnDisplayMenu) {
      this.rol = +localStorage.getItem('Rol');
    }

  }
  buscar() {

    this.vehicleService.getVehicleByVIN(this.VIN)

      .subscribe(data => {

        let rut = "/vehicle/" + data.Id;
        this.router.navigate([rut]);
      },
      error => { this.menssage.error(error._body); });


  }

}
