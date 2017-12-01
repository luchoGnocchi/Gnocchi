import { Component, OnInit, OnChanges, Input } from '@angular/core';

import { Vehicle } from '../../models/Vehicle';
import {  VehicleType } from '../../models/VehicleType';
import {  Inspection} from '../../models/Inspection';
import {  DamageRegistry } from '../../models/DamageRegistry';
import { InspectionService } from '../../services/inspection.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import swal from 'sweetalert2';

@Component({
  selector: 'app-inspection',
  templateUrl: './inspection.component.html',
  providers: [InspectionService, Inspection]
})
export class InspectionComponent implements OnInit {
  pageTitle: string = "Inspecciones" + "";
  listFilter: string = "";
  imageWidth: number = 100;
  imageMargin: number = 1;
  showImage: boolean = false;
  inspections: Array<Inspection>;
  errorMessage: string;

  @Input() Vehicle: Vehicle;
  constructor(private _inspectionService: InspectionService, private router: Router) {
  }

  ngOnInit() {
    this._inspectionService.getInspections()
      .subscribe(inspectionsObtained => this.inspections = inspectionsObtained,
      error => this.errorMessage = <any>error);
  }

}
