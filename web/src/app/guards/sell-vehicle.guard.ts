import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class SellVehicleGuard implements CanActivate {
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let idRol = +localStorage.getItem('Rol');
    console.log(idRol);
    return idRol == 5 || idRol == 1;
  }
}
