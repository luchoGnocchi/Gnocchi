import { Component, ViewEncapsulation, OnInit, OnChanges, Input, Output, EventEmitter  } from '@angular/core';
import { InspectionService } from '../../../services/inspection.service';
import { Vehicle } from '../../../models/Vehicle';
import { Inspection  } from '../../../models/Inspection';
import { DamageRegistry  } from '../../../models/DamageRegistry';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"
import { MessageManagerService } from '../../../services/message-manager.service';
@Component({
  selector: 'app-add-inspection',
  templateUrl: './add-inspection.component.html'
})
export class AddInspectionComponent
// tslint:disable-next-line:one-line
{
  texto: string;
  inspectionNew: Inspection = new Inspection();

  idRol = +localStorage.getItem('Rol');
  closeResult: string;
  @Input() vehicle: Vehicle;
  lastDames:   Array<DamageRegistry>;
  vin:string;
  constructor(private modalService: NgbModal, private inspectionService: InspectionService, private menssage: MessageManagerService) {

  }
  open(content) {
    this.vin=this.vehicle.VIN;
    this.inspectionNew.DamageRegistries=new Array<DamageRegistry>();
    this.modalService.open(content, { windowClass: 'dark-modal' });
    console.log(this.vehicle);
    this.lastDames=this.vehicle.Inspections[0].DamageRegistries;
  }
  guardar() {
console.log("pasa x  aca ");
let vehicleAux:Vehicle=new Vehicle();
vehicleAux.VIN=this.vin;
    this.inspectionNew.Vehicle=vehicleAux;
    this.inspectionService.create(this.inspectionNew).subscribe(
      data => { this.menssage.success(data.text())},
      error => { this.menssage.error(error._body); });
  }
  AgregarInspeccion(x: any) {
    let toInsert = new  DamageRegistry();
    toInsert.Description = x.name;
    toInsert.Image = x.avatar.Image;
    this.inspectionNew.DamageRegistries.push(toInsert);

console.log("adsdasdasdsadas", x.avatar.Image);
console.log("la inspecccion ", this.inspectionNew);
  }



}
