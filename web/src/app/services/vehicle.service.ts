import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';
import { ConfigurationService } from '../app.configuration.service';

import { Vehicle } from '../models/Vehicle';
import {  Sell } from '../models/Sell';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
@Injectable()
export class VehicleService {
    urlVehicle: string = "";

    constructor(private _httpService: Http, private configurationService: ConfigurationService) {
        this.urlVehicle = configurationService.webApiURL + "/Vehicle";
    }

    getVehicles(): Observable<Array<Vehicle>> {

        return this._httpService.get(this.urlVehicle)
            .map((response: Response) => <Array<Vehicle>>response.json())

            .catch(this.handleError);
    }
    getVehicle(id: string): Observable<Vehicle> {
        return this._httpService.get(this.urlVehicle + "/" + id)
            .map(response => response.json())
            .catch(this.handleError);
    }
    sellVehicle(vehicle: Vehicle, sell: Sell) {
        let header = new Headers();
        header.append("oauth_token", localStorage.getItem('Token'));
        return this._httpService.post(this.urlVehicle + "/sell?VIN=" + vehicle.VIN, sell, {
            headers: header
        }).map(res => {
            return res;
        });
    }
    getVehiclesOutBatch(): Observable<Array<Vehicle>> {

        return this._httpService.get(this.urlVehicle + "/GetVehicleOutBatch")
            .map((response: Response) => <Array<Vehicle>>response.json())

            .catch(this.handleError);
    }
    GetVehicleReadyToSell(): Observable<Array<Vehicle>> {

        return this._httpService.get(this.urlVehicle + "/GetVehicleReadyToSell")
            .map((response: Response) => <Array<Vehicle>>response.json())

            .catch(this.handleError);
    }

    getVehicleByVIN(VIN: string): Observable<Vehicle> {
        return this._httpService.get(this.urlVehicle + "/VehicleByVIN?Vin=" + VIN)
            .map(response => response.json())
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
