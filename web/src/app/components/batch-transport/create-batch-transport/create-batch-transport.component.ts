
import { Component, ViewEncapsulation, OnInit, OnChanges, Input } from '@angular/core';
import { BatchService } from '../../../services/batch.service';
import { BatchTransportService } from '../../../services/batch-transport.service';
import { MessageManagerService } from '../../../services/message-manager.service';
import {  BatchTransport } from '../../../models/BatchTransport';
import { Batch } from '../../../models/Batch';

import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"


@Component({
  selector: 'app-create-batch-transport',
  templateUrl: './create-batch-transport.component.html',
  styleUrls: ['./create-batch-transport.component.css'],
  providers: [BatchService]
})
export class CreateBatchTransportComponent implements OnInit {
  batchTransport: BatchTransport = new BatchTransport();

  batchsFree: Array<Batch>;
  errorMessage: string;
  constructor(private batchTransportService: BatchTransportService, private batchService: BatchService, private modalService: NgbModal, private menssage: MessageManagerService) { }


  ngOnInit() {
    this.batchService.getBatchs()
      .subscribe(batchsFreeObtained => this.batchsFree = batchsFreeObtained,
      error => this.errorMessage = <any>error);
  }
  register() {

    this.batchTransport.Batchs = new Array<Batch>();
    for (let entry of $("#cmbBatchs").val()) {
      let valSplit = entry.split("'", 3);
      let BatchToTransport: Batch = new Batch();
      BatchToTransport.Id = +valSplit[1];
      this.batchTransport.Batchs.push(BatchToTransport);
    }

    this.batchTransportService.create(this.batchTransport).subscribe(
      data => { this.menssage.success(data.text()) },
      error => { this.menssage.error(error._body); });
  }
  open(content) {

    this.modalService.open(content, { windowClass: 'dark-modal' });
    setTimeout(function () { $("#cmbBatchs").select2(); }, 1);
  }

}