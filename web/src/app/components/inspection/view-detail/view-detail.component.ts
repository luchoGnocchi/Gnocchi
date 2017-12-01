



import { Component, ViewEncapsulation, OnInit, OnChanges, Input, Output, EventEmitter  } from '@angular/core';
import { InspectionService } from '../../../services/inspection.service';
import { Vehicle } from '../../../models/Vehicle';
import { Inspection  } from '../../../models/Inspection';
import { DamageRegistry  } from '../../../models/DamageRegistry';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"
import { MessageManagerService } from '../../../services/message-manager.service';
@Component({
  selector: 'app-view-detail-Inspection',
  templateUrl: './view-detail.component.html',
  styleUrls: ['./view-detail.component.css']
})
export class ViewDetailComponent
// tslint:disable-next-line:one-line
{
  @Input() inspectionNew: Inspection;


  constructor(private modalService: NgbModal, private inspectionService: InspectionService, private menssage: MessageManagerService) {

  }
  open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });
  }





}
