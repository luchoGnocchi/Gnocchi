import { Injectable } from '@angular/core';
import swal from 'sweetalert2';
@Injectable()
export class MessageManagerService {

  constructor() { }
  success(msj: string) {
    swal("Felicitaciones!!", msj, "success");
    // location.reload();
  }
  error(msj: string) {
    swal("Ops.. ", msj, "error");
  }

}
