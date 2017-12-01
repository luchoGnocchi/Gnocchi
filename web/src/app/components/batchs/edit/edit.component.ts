
import { Component, ViewEncapsulation, OnInit, OnChanges, Input } from '@angular/core';
import { BatchService } from '../../../services/batch.service';
import { Vehicle } from '../../../models/Vehicle';
import { Batch } from '../../../models/Batch';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"
import { MessageManagerService } from '../../../services/message-manager.service';
@Component({
  selector: 'app-edit-batch',
  templateUrl: './edit.component.html'
})
export class EditComponent implements OnInit {

  constructor(private batchService: BatchService, private modalService: NgbModal, private menssage: MessageManagerService) { }
  @Input() batch: Batch;
  ngOnInit() {
  }
  update() {
    this.batchService.update(this.batch).subscribe(
      data => { this.menssage.success(data.text()) },
      error => { this.menssage.error(error._body); });
  }
  open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });
  }

}
