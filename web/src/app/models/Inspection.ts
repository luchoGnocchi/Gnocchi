import { DamageRegistry } from "./DamageRegistry";
import { User } from "./User";
import { Vehicle } from "./Vehicle";
export class Inspection {
    DamageRegistries: DamageRegistry[]= new  Array<DamageRegistry>();
    Id: number;
    Status: number;
    DateAndTime: Date;
    Place: number;
    Inspector?: User;
    VehicleId: number;
    Vehicle: Vehicle;
}
