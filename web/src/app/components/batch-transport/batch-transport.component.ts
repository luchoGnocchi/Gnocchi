import { Component, OnInit } from '@angular/core';
import { BatchTransportService } from '../../services/batch-transport.service';
import { MessageManagerService } from '../../services/message-manager.service';
import { BatchTransport } from '../../models/BatchTransport';
import swal from 'sweetalert2';
@Component({
  selector: 'app-batch-transport',
  templateUrl: './batch-transport.component.html',
  providers: [BatchTransportService]
})
export class BatchTransportComponent implements OnInit {
  pageTitle: string = "Lista de Transportes";
  batchsTransports: Array<BatchTransport>;
  errorMessage: string;
  constructor(private batchTransportService: BatchTransportService, private menssage: MessageManagerService) { }

  ngOnInit() {
    this.batchTransportService.getBatchTransports()
      .subscribe(BatchsObtained => {
        this.batchsTransports = BatchsObtained;
        console.log(BatchsObtained)
      },
      error => this.errorMessage = <any>error);
  }
  startTravel(id: number): void {
    this.batchTransportService.startTravel(id).subscribe(
      data => { this.menssage.success(data.text()) },
      error => { this.menssage.error(error._body); });;
  }
  finishTravel(id: number): void {
    this.batchTransportService.finishTravel(id).subscribe(
      data => { this.menssage.success(data.text()) },
      error => { this.menssage.error(error._body); });
  }
}


