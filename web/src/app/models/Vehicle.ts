import { Batch } from "./Batch";
import { HistoryState } from "./HistoryState";
import { Inspection } from "./Inspection";
import { MovementInZone } from "./MovementInZone";
import { Zone } from "./Zone";

export class Vehicle {
    Batch: Batch;
    HistoryState: HistoryState[];
    Inspections: Inspection[];
    MovementInZone: MovementInZone[];
    zone: Zone;
    Id: number;
    Brand: string;
    Model: string;
    Year: number;
    BatchId: number;
    ZoneId: number;
    Color: string;
    VehicleType: number;
    VIN: string;
    constructor()
    // tslint:disable-next-line:one-line
    {
        this.Id = 2;
        this.Brand = 'Corolla';
        this.Model = 'Toyota';
        this.Year = 2016;
        this.Color = 'Rojo';
        this.VehicleType = 1;
        this.VIN = 'VIN 123';
    }
}