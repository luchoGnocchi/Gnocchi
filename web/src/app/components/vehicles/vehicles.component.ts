import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../../models/Vehicle';
import { VehicleType } from '../../models/VehicleType';
import { Inspection } from '../../models/Inspection';
import { DamageRegistry } from '../../models/DamageRegistry';
import { VehicleService } from '../../services/vehicle.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-vehicles',
  templateUrl: './vehicles.component.html',
  providers: [VehicleService, Inspection]
})
export class VehiclesComponent implements OnInit {
  pageTitle: string = "Lista de vehiculos";
  idRol = +localStorage.getItem('Rol');
  vehicles: Array<Vehicle>;
  errorMessage: string;
  constructor(private _vehicleService: VehicleService, private router: Router) { }

  ngOnInit() {
    this._vehicleService.getVehicles()
      .subscribe(vehiclesObtained => this.vehicles = vehiclesObtained,
      error => this.errorMessage = <any>error);
  }
  verVehicle(id: number)
  // tslint:disable-next-line:one-line
  {
    this.router.navigate(['vehicle', id]);

  }
}
