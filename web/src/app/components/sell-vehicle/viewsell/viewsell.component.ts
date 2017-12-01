import { Component, EventEmitter, ViewEncapsulation, Input, OnInit, OnChanges, Output } from '@angular/core';
import {   Sell } from '../../../models/Sell';
import { Vehicle  } from '../../../models/Vehicle';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"
import { MessageManagerService } from '../../../services/message-manager.service';
import { VehicleService } from '../../../services/vehicle.service';
@Component({
  selector: 'app-viewsell',
  templateUrl: './viewsell.component.html',
  styleUrls: ['./viewsell.component.css']
})
export class ViewsellComponent implements OnInit {
  ngOnInit() {

  }
  texto: string;
  closeResult: string;
  @Input() vehicle: Vehicle;
  constructor(private modalService: NgbModal, private vehicleService: VehicleService, private menssage: MessageManagerService) { }
  open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });
  }






}