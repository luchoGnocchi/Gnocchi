import { Component, EventEmitter, ViewEncapsulation, Input, OnInit, OnChanges, Output } from '@angular/core';

import { DamageRegistry } from '../../../models/DamageRegistry';
import { Vehicle } from '../../../models/Vehicle';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from "@angular/forms"
import { MessageManagerService } from '../../../services/message-manager.service';
import { ElementRef, ViewChild} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
@Component({
  selector: 'app-add-damage',
  templateUrl: './add-damage.component.html'
})
export class AddDamageComponent {
  form: FormGroup;
  loading: boolean = false;
  vehicle: Vehicle;

  @ViewChild('fileInput') fileInput: ElementRef;
  @Output() AgregarInspeccion: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();
  constructor(private modalService: NgbModal, private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      avatar: null
    });
  }

  onFileChange(event) {
    let reader = new FileReader();
    if(event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.form.get('avatar').setValue({
          Description: file.name,
          filetype: file.type,
          Image: reader.result.split(',')[1]
        });

      };
    }
  }

  onSubmit() {
    const formModel = this.form.value;
    this.loading = true;
    // this.http.post('apiUrl', formModel)
    setTimeout(() => {
      console.log(formModel);
   // this.vehicle.Inspections.l
      this.loading = false;
      this.AgregarInspeccion.emit(formModel);
    }, 1000);
  }

  clearFile() {
    this.form.get('avatar').setValue(null);
    this.fileInput.nativeElement.value = '';
  }
open(content) {
    this.modalService.open(content, { windowClass: 'dark-modal' });
  }
}

