import { Component, OnInit } from '@angular/core';
import { Vehicle  } from '../../models/Vehicle';
import {   VehicleType  } from '../../models/VehicleType';
import {   Inspection } from '../../models/Inspection';
import {  DamageRegistry } from '../../models/DamageRegistry';
import { VehicleService } from '../../services/vehicle.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sell-vehicle',
  templateUrl: './sell-vehicle.component.html'
})
export class SellVehicleComponent implements OnInit {

  pageTitle: string = "Vender Vehiculos ";

  vehicles: Array<Vehicle>;
  errorMessage: string;
  constructor(private _vehicleService: VehicleService, private router: Router) { }

  ngOnInit() {
    this._vehicleService.GetVehicleReadyToSell()
      .subscribe(vehiclesObtained => this.vehicles = vehiclesObtained,
      error => this.errorMessage = <any>error);
  }
}
