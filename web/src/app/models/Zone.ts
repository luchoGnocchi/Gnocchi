import { Vehicle } from "./Vehicle";
export class Zone {
    SubZones?: Zone[];
    Vehicles?: Vehicle[];
    Id: number;
    Name: string;
    MaxCapacity: number;
    UsedCapacity: number;
}