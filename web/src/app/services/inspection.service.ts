import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';
import { Inspection } from '..//models/Inspection';
import { ConfigurationService } from '../app.configuration.service';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
@Injectable()
export class InspectionService {


    constructor(private _httpService: Http, private configurationService: ConfigurationService) {

    }
    urlInspection(): string {
        return this.configurationService.webApiURL + '/Inspection';
    }
    getInspections(): Observable<Array<Inspection>> {

        return this._httpService.get(this.urlInspection())
            .map((response: Response) => <Array<Inspection>>response.json())
            // .do(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }
    getInspection(id: string): Observable<Inspection> {
        return this._httpService.get(this.urlInspection() + "/" + id)
            .map(response => response.json())
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    create(inspection: Inspection) {
        let header = new Headers();
        header.append("oauth_token", localStorage.getItem('Token'));
        return this._httpService.post(this.urlInspection(), inspection, {
            headers: header
        }).map(res => {
            return res;
        });
    }
}
