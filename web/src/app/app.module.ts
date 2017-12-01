import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpModule } from '@angular/http';
import {ReactiveFormsModule} from "@angular/forms";

//rutas
import { APP_ROUTING } from './app.routes';
//componentes
import { AppComponent } from './app.component';
import { UserEditComponent } from './components/users/user-edit/user-edit.component';
import { UserViewComponent } from './components/users/user-view/user-view.component';
import { AddDamageComponent } from './components/inspection/add-damage/add-damage.component'
import { HistoryComponent } from './components/vehicles/history/history.component';
import { MovementInZonesComponent } from './components/vehicles/movement-in-zones/movement-in-zones.component';
import { BatchsComponent } from './components/batchs/batchs.component';
import { CreateComponent } from './components/batchs/create/create.component';
import { EditComponent } from './components/batchs/edit/edit.component';
import { RemoveComponent } from './components/batchs/remove/remove.component';
import { ViewComponent } from './components/batchs/view/view.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { AboutComponent } from './components/about/about.component';
import { VehiclesComponent } from './components/vehicles/vehicles.component';
import { HomeComponent } from './components/home/home.component';
import { VehicleDetailComponent } from './components/vehicles/vehicle-detail/vehicle-detail.component';
import { LoginComponent } from './components/login/login.component';
import { InspectionComponent } from './components/inspection/inspection.component';
import { AddInspectionComponent } from './components/inspection/add-inspection/add-inspection.component';
import { BatchTransportComponent } from './components/batch-transport/batch-transport.component';
import { UserCreateComponent } from './components/users/user-create/user-create.component';
import { UsersComponent } from './components/users/users.component';
import { CreateBatchTransportComponent } from './components/batch-transport/create-batch-transport/create-batch-transport.component';


//Servicios

import { ConfigurationService } from './app.configuration.service';
import { InspectionService } from './services/inspection.service';
import { BatchService } from './services/batch.service';
import { UserService } from './services/user.service';
import { BatchTransportService } from './services/batch-transport.service';
import { MessageManagerService } from './services/message-manager.service';
import { ZoneService } from './services/zone.service';
import { VehicleService } from './services/vehicle.service';


//plugins
import { ImageUploadModule } from "angular2-image-upload";
import { Select2Module } from 'ng2-select2';
import { AddMovementComponent } from './components/vehicles/movement-in-zones/add-movement/add-movement.component';


//Guards 
import { BatchGuard } from './guards/batch.guard';
import { BatchTransportGuard } from './guards/batch-transport.guard';
import { SellVehicleGuard } from './guards/sell-vehicle.guard';
import { UsersGuard } from './guards/users.guard';
import { VehicleDetailGuard } from './guards/vehicle-detail.guard';
import { VehiclesGuard } from './guards/vehicles.guard';
import { SellVehicleComponent } from './components/sell-vehicle/sell-vehicle.component';
import { CreatesellComponent } from './components/sell-vehicle/createsell/createsell.component';
import { ViewsellComponent } from './components/sell-vehicle/viewsell/viewsell.component';
import { ViewDetailComponent } from './components/inspection/view-detail/view-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AboutComponent,
    VehiclesComponent,
    HomeComponent,
    VehicleDetailComponent,
    LoginComponent,
    InspectionComponent,
    AddInspectionComponent,
    UsersComponent,
    UserCreateComponent,
    UserEditComponent,
    UserViewComponent,
    AddDamageComponent,
    HistoryComponent,
    BatchsComponent,
    CreateComponent,
    EditComponent,
    RemoveComponent,
    ViewComponent,
    BatchTransportComponent,
    CreateBatchTransportComponent,
    MovementInZonesComponent,
    AddMovementComponent,
    SellVehicleComponent,
    CreatesellComponent,
    ViewsellComponent,
    ViewDetailComponent
  ],
  imports: [
    BrowserModule,
    APP_ROUTING,
    HttpModule,
    NgbModule.forRoot(),
    FormsModule,
    ImageUploadModule.forRoot(),
    Select2Module,
    ReactiveFormsModule
  ],
  providers: [
    VehicleService,
    ConfigurationService,
    UserService,
    BatchTransportService,
    BatchService,
    MessageManagerService,
    ZoneService,
    BatchGuard,
    BatchTransportGuard,
    SellVehicleGuard,
    UsersGuard,
    VehicleDetailGuard,
    VehiclesGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
