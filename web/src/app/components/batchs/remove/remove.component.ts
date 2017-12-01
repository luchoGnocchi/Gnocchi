
import { Component, ViewEncapsulation, OnInit, OnChanges, Input } from '@angular/core';
import { BatchService } from '../../../services/batch.service';
import { VehicleService } from '../../../services/vehicle.service';
import { Batch } from '../../../models/Batch';
import { Vehicle } from '../../../models/Vehicle';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"
import { MessageManagerService } from '../../../services/message-manager.service';
@Component({
  selector: 'app-remove-batch',
  templateUrl: './remove.component.html'
})
export class RemoveComponent implements OnInit {

  constructor(private batchService: BatchService, private modalService: NgbModal, private menssage: MessageManagerService) { }
  @Input() batch: Batch;

  ngOnInit() {
  }
  eliminiar() {
    this.batchService.delete(this.batch).subscribe(
      data => { this.menssage.success(data.text()) },
      error => { this.menssage.error(error._body); });

  }
  open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });
  }

}
