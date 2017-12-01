import {Component, ViewEncapsulation, OnInit, OnChanges, Input,Output } from '@angular/core';
import { ZoneService } from '../../../../services/zone.service';
import {Zone} from '../../../../models/Zone';
import {Vehicle} from '../../../../models/Vehicle';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {NgForm} from "@angular/forms"
import {MessageManagerService } from '../../../../services/message-manager.service';

@Component({
  selector: 'app-add-movement',
  templateUrl: './add-movement.component.html'
})
export class AddMovementComponent  {
  texto:string;
  zones:Array<Zone>;
  zone:Zone;
  closeResult: string;
  @Input() Vehicle: Vehicle;
  constructor(private modalService: NgbModal, private zoneService:ZoneService, private menssage:MessageManagerService) {}
  open(content) {
    console.log(this.Vehicle);
    this.modalService.open(content, { windowClass: 'dark-modal' });
    this.zoneService.getZones()
    .subscribe(zones => this.zones = zones,
            error => this.menssage.error(<any>error._body));
  }
  guardar() {
    console.log(this.zone);

//this.zoneService.Vehicle=this.vehicle;
    this.zoneService.addVehicle(this.Vehicle,this.zone.Id).subscribe(
      data =>    {this.menssage.success(data.text()) },
      error => {this.menssage.error(error._body); });
  }




}
