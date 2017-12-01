
import { Component, ViewEncapsulation, OnInit, OnChanges, Input } from '@angular/core';
import { BatchService } from '../../../services/batch.service';
import { VehicleService } from '../../../services/vehicle.service';

import { Batch } from '../../../models/Batch';
import { Vehicle } from '../../../models/Vehicle';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"

@Component({
  selector: 'app-view-batch',
  templateUrl: './view.component.html',
  providers: [VehicleService]
})
export class ViewComponent implements OnInit {
  @Input() batch: Batch;
  errorMessage: string;
  constructor(private vehicleService: VehicleService, private batchService: BatchService, private modalService: NgbModal) { }

  ngOnInit() {
  }
  open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });
  }


}
