export class Reservation {
    id: number;
    clientId: number;
    serviceId: number;
    reservationDate: Date;

    constructor(id: number, clientId: number, serviceId: number, reservationDate: Date) 
    {
        this.id = id;
        this.clientId = clientId;
        this.serviceId = serviceId;
        this.reservationDate = reservationDate;
    }
}
