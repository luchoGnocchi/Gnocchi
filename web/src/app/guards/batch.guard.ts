import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class BatchGuard implements CanActivate {
  constructor(private route: Router) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let idRol = +localStorage.getItem('Rol');
    return idRol == 2 || idRol == 1;
  }
}




