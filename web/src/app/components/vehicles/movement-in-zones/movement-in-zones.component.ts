import { Component, OnInit, OnChanges, Input } from '@angular/core';
import { Vehicle  } from '../../../models/Vehicle';
import {  VehicleType } from '../../../models/VehicleType';
import { Inspection } from '../../../models/Inspection';
import {  DamageRegistry } from '../../../models/DamageRegistry';
import {Router} from '@angular/router';
import {NgForm} from '@angular/forms';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-movement-in-zones',
  templateUrl: './movement-in-zones.component.html'
})
export class MovementInZonesComponent implements OnInit {
   
  errorMessage: string;
  @Input() Vehicle:Vehicle;
  constructor() { }
  
  
  ngOnInit() {
    console.log("aaaaaaaaa",this.Vehicle.MovementInZone);
  }

  haciendoclick() {
    console.log(this.Vehicle)
  } }