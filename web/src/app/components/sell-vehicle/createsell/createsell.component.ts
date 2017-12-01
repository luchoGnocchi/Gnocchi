import { Component, EventEmitter, ViewEncapsulation, Input, OnInit, OnChanges, Output } from '@angular/core';
import { Vehicle  } from '../../../models/Vehicle';
import {  Sell } from '../../../models/Sell';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"
import { MessageManagerService } from '../../../services/message-manager.service';
import { VehicleService } from '../../../services/vehicle.service';
@Component({
  selector: 'app-createsell',
  templateUrl: './createsell.component.html',
  styleUrls: ['./createsell.component.css']
})
export class CreatesellComponent implements OnInit {
  sell: Sell;


  ngOnInit() {
    this.sell = new Sell();
    this.sell.Name
  }
  texto: string;
  closeResult: string;
  @Input() vehicle: Vehicle;
  constructor(private modalService: NgbModal, private vehicleService: VehicleService, private menssage: MessageManagerService) { }
  open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });
  }
  guardar() {
    this.vehicleService.sellVehicle(this.vehicle, this.sell).subscribe(
      data => { this.menssage.success(data.text()) },
      error => { this.menssage.error(error._body); });
  }




}