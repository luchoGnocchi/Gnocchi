import { Batch } from "./Batch";
import { User } from "./User"; 
export class BatchTransport {
    Id: number;
    Batchs: Batch[];
    Transporter: User;
    Creator: User;
    StartDate: Date;
    FinishDate: Date;
}