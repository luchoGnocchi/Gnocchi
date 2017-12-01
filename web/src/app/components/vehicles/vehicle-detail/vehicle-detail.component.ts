import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Vehicle } from '../../../models/Vehicle';
import {  VehicleType } from '../../../models/VehicleType';
import { VehicleService } from '../../../services/vehicle.service';
import { Observable } from 'rxjs/Observable';
import { Location } from '@angular/common';
@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  providers: [VehicleService]
})
export class VehicleDetailComponent implements OnInit {

  vehicle: Vehicle = new Vehicle();
  errorMessage: string;
  constructor(private activatedRoute: ActivatedRoute, private _vehicleService: VehicleService, private _location: Location) {
    this.activatedRoute.params.subscribe(params => {
      this._vehicleService.getVehicle(params['id'])
        .subscribe(petsObtained => this.vehicle = petsObtained,
        error => this.errorMessage = <any>error);
    });
  }

  ngOnInit() {

  }
  public backClicked() {
    this._location.back();

  }

}
