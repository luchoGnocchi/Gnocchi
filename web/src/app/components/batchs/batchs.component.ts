import { Component, OnInit } from '@angular/core';
import { BatchService } from '../../services/batch.service';
import { Batch } from '../../models/Batch';
@Component({
  selector: 'app-batchs',
  templateUrl: './batchs.component.html',
  styles: [],
  providers: [BatchService]
})
export class BatchsComponent implements OnInit {
  pageTitle: string = "Lista de lotes";
  batchs: Array<Batch>;
  errorMessage: string;
  constructor(private batchService: BatchService) { }

  ngOnInit() {
    this.batchService.getBatchs()
      .subscribe(BatchsObtained => {
      this.batchs = BatchsObtained
        ; console.log(BatchsObtained)
      },
      error => this.errorMessage = <any>error);
  }

}



