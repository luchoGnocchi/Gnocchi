import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';
import { ConfigurationService } from '../app.configuration.service';
import {  Vehicle } from '../models/Vehicle';
import { Zone } from '../models/Zone';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

@Injectable()
export class ZoneService {
  configurationServiceLocal: ConfigurationService;
  constructor(private _httpService: Http, private configurationService: ConfigurationService) {

    this.configurationServiceLocal = configurationService;
  }
  urlZone(): string {
    return this.configurationServiceLocal.getWebApiURL() + "/Zone";

  }
  urlAddVehicleToZone(): string {
    return this.configurationServiceLocal.getWebApiURL() + "/Zone/AddVehicle?id=";
  }

  getZones(): Observable<Array<Zone>> {
    return this._httpService.get(this.urlZone())
      .map((response: Response) => <Array<Zone>>response.json())
      // .do(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data)))
      .catch(this.handleError);
  }
  getZone(id: string): Observable<Zone> {
    return this._httpService.get(this.getZones() + "/" + id)
      .map(response => response.json())
      .catch(this.handleError);
  }
  private handleError(error: Response) {
    console.error(error);
    return Observable.throw(error.json().error || 'Server error');
  }
  addVehicle(vehcileToAdd: Vehicle, zone: number) {
    let header = new Headers();
    let ve=new Vehicle();
    ve.VIN=vehcileToAdd.VIN;
    console.log("sdadsa", vehcileToAdd);
    console.log(this.urlAddVehicleToZone() + zone);
    header.append("oauth_token", localStorage.getItem('Token'));
    return this._httpService.post(this.urlAddVehicleToZone() + zone, ve, {
      headers: header
    }).map(res => {
      return res;
    });
  }
}
