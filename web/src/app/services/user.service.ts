import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers } from '@angular/http';
import { ConfigurationService } from '../app.configuration.service';
import { User } from '../models/User';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import swal from 'sweetalert2';

@Injectable()
export class UserService {


    //private WEB_API_URL: string = 'http://localhost:54649/api/vehicle';
    //urlUsers: string = "";
    configurationServiceLocal: ConfigurationService;
    userLoged: User;
    tokenChanged = new Subject<any>();
    tokenKey: string = "";

    newTokenEmitted = this.tokenChanged.asObservable();
    constructor(private _httpService: Http, private configurationService: ConfigurationService) {
        this.configurationServiceLocal = configurationService;

    }
    urlUsers(): string {
        return this.configurationServiceLocal.getWebApiURL() + "/Users";
    }
    urlLogin(): string {
        return this.configurationServiceLocal.getWebApiURL() + "login";
    }
    getUsers(): Observable<Array<User>> {
        return this._httpService.get(this.urlUsers())
            .map((response: Response) => <Array<User>>response.json())
            // .do(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }
    getUser(id: string): Observable<User> {
        return this._httpService.get(this.urlUsers + "/" + id)
            .map(response => response.json())
            .catch(this.handleError);
    }


    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    isLogged(): boolean {
        return this.tokenKey != "";
    }
    getUserByToken(): Observable<User> {
        let parameters = "CurrentUserLoged?token=" + this.tokenKey;
        return this._httpService.post(this.configurationServiceLocal.webApiURL + parameters, null)
            .map(response => response.json())
            .catch(this.handleError);
    }

    create(userToCreate: User) {
        let header = new Headers();
        header.append("oauth_token", localStorage.getItem('Token'));
        return this._httpService.post(this.urlUsers(), userToCreate, {
            headers: header
        }).map(res => {
            return res;
        });
    }
    update(userToUpdate: User) {
        let header = new Headers();

        //    let parameters = "?productID=" + productID + "&reviewMsg=" + msg;
        //   let token_user = this.loginService.tokenKey;

        header.append("oauth_token", localStorage.getItem('Token'));
        return this._httpService.put(this.urlUsers() + "/" + userToUpdate.Id, userToUpdate, {
            headers: header
        });
    }
    getToken(username: string, password: string) {

        let url = this.urlLogin();
        var header = new Headers();
        let userToSend: User = new User();
        userToSend.UserName = username;
        userToSend.Password = password;
        header.append("Content-Type", "application/json");
        return this._httpService.post(url, userToSend, {
            headers: header
        })
            .map(res => {
                this.tokenKey = res.json();
                return res.json();
            });

    }
    clearCokis() {
        this.userLoged = null;
        this.tokenKey = "";
    }




}
