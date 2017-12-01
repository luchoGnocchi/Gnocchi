import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';
import { ConfigurationService } from '../app.configuration.service';
import { BatchTransport } from '../models/BatchTransport';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
@Injectable()
export class BatchTransportService {

  configurationServiceLocal: ConfigurationService;
  constructor(private _httpService: Http, private configurationService: ConfigurationService) {

    this.configurationServiceLocal = configurationService;
  }
  urlBatch(): string {
    return this.configurationServiceLocal.getWebApiURL() + "/BatchTransport";
  }
  urlStartTravel(): string {
    return this.configurationServiceLocal.getWebApiURL() + "/StartTransport"
  }
  urlFinishTravel(): string {
    return this.configurationServiceLocal.getWebApiURL() + "/FinshiTransport"
  }

  getBatchTransports(): Observable<Array<BatchTransport>> {
    return this._httpService.get(this.urlBatch())
      .map((response: Response) => <Array<BatchTransport>>response.json())
      // .do(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data)))
      .catch(this.handleError);
  }
  getBatch(id: string): Observable<BatchTransport> {
    return this._httpService.get(this.urlBatch + "/" + id)
      .map(response => response.json())
      .catch(this.handleError);
  }
  private handleError(error: Response) {
    console.error(error);
    return Observable.throw(error.json().error || 'Server error');
  }
  create(batchToCreate: BatchTransport) {
    let header = new Headers();
    header.append("oauth_token", localStorage.getItem('Token'));
    return this._httpService.post(this.urlBatch(), batchToCreate, {
      headers: header
    });
  }

  update(batchToUpdate: BatchTransport) {
    let header = new Headers();
    header.append("oauth_token", localStorage.getItem('Token'));
    return this._httpService.put(this.urlBatch() + "/" + batchToUpdate.Id, batchToUpdate, {
      headers: header
    });
  }
  delete(batchToDelete: BatchTransport) {
    let header = new Headers();
    header.append("oauth_token", localStorage.getItem('Token'));
    return this._httpService.delete(this.urlBatch() + "/" + batchToDelete.Id, {
      headers: header
    });

  }

  startTravel(id: number) {
    let header = new Headers();
    header.append("oauth_token", localStorage.getItem('Token'));
    return this._httpService.post(this.urlStartTravel() + "?IdbatchTransport=" + id, null, {
      headers: header
    });
  }
  finishTravel(id: number) {
    let header = new Headers();
    header.append("oauth_token", localStorage.getItem('Token'));
    return this._httpService.post(this.urlFinishTravel() + "?IdbatchTransport=" + id, null, {
      headers: header
    });
  }

}

