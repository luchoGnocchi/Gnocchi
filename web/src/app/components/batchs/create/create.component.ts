
import { Component, ViewEncapsulation, OnInit, OnChanges, Input } from '@angular/core';
import { BatchService } from '../../../services/batch.service';
import { VehicleService } from '../../../services/vehicle.service';

import {  Vehicle } from '../../../models/Vehicle';
import { Batch  } from '../../../models/Batch';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"
import { MessageManagerService } from '../../../services/message-manager.service';
@Component({
  selector: 'app-create-batch',
  templateUrl: './create.component.html',
  providers: [VehicleService]
})
export class CreateComponent implements OnInit {
  batch: Batch = new Batch();
  vehiclesInBatch: Array<Vehicle>;
  vehicles: Array<Vehicle>;
  errorMessage: string;
  constructor(private vehicleService: VehicleService, private batchService: BatchService, private modalService: NgbModal, private menssage: MessageManagerService) { }


  ngOnInit() {
    this.vehicleService.getVehiclesOutBatch()
      .subscribe(vehiclesObtained => this.vehicles = vehiclesObtained,
      error => this.errorMessage = <any>error);
  }
  register() {
    this.batch.Vehicles = new Array<Vehicle>();
    for (let entry of $("#cmbVehicle").val()) {
      let das = entry.split("'", 3);
      let vehicleToBatch: Vehicle = new Vehicle();
      console.log("vehicle", vehicleToBatch);
      vehicleToBatch.VIN = das[1];
      this.batch.Vehicles.push(vehicleToBatch);
    }
    this.batchService.create(this.batch).subscribe(
      data => { this.menssage.success(data.text()) },
      error => { this.menssage.error(error._body); });
  }
  open(content) {

    this.modalService.open(content, { windowClass: 'dark-modal' });
    setTimeout(function () { $("#cmbVehicle").select2(); }, 1);
  }

}






