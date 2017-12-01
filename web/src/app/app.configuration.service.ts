
import { Injectable } from '@angular/core';
import { User } from "./models/User";

///Service class to call REST API
@Injectable()
export class ConfigurationService {
    
    public webApiURL: string = "http://localhost:54649/Api/";
    public blnDisplayMenu:boolean;
    public currectUser:User;
       constructor() { 

        this.blnDisplayMenu = false;
    }
     
 
    getWebApiURL(): string {

       return this.webApiURL;
    }
}