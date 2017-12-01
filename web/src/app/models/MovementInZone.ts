import { Zone } from "./Zone"; 
export class MovementInZone {
    DestinationZone: Zone;
    OriginZone: Zone;
    User?: any;
    Id: number;
    Time: Date;
}