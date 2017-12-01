import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { HomeComponent } from './components/home/home.component';
import { VehiclesComponent } from './components/vehicles/vehicles.component';
import { VehicleDetailComponent } from './components/vehicles/vehicle-detail/vehicle-detail.component';
import { UsersComponent } from './components/users/users.component'
import { LoginComponent } from './components/login/login.component';
import { BatchsComponent } from './components/batchs/batchs.component';
import { BatchTransportComponent } from './components/batch-transport/batch-transport.component';
import { SellVehicleComponent } from "./components/sell-vehicle/sell-vehicle.component";
//guards
import { BatchGuard } from './guards/batch.guard';
import { BatchTransportGuard } from './guards/batch-transport.guard';
import { SellVehicleGuard } from './guards/sell-vehicle.guard';
import { UsersGuard } from './guards/users.guard';
import { VehicleDetailGuard } from './guards/vehicle-detail.guard';
import { VehiclesGuard } from './guards/vehicles.guard';

const APP_ROUTES: Routes = [
  { path: 'about', component: AboutComponent },
  { path: 'home', component: HomeComponent },
  { path: 'vehicle', component: VehiclesComponent, canActivate: [VehiclesGuard] },
  { path: 'vehicle/:id', component: VehicleDetailComponent, canActivate: [VehicleDetailGuard] },
  { path: 'users', component: UsersComponent, canActivate: [UsersGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'batch', component: BatchsComponent, canActivate: [BatchGuard] },
  { path: 'batchTransport', component: BatchTransportComponent, canActivate: [BatchTransportGuard] },
  { path: 'sell', component: SellVehicleComponent, canActivate: [SellVehicleGuard] },
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES);

