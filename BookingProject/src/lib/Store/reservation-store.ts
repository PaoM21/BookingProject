import { writable, type Writable } from 'svelte/store';
import { Reservation } from '../Model/booking-entity';
const objectReservation = new Reservation(0, 0, 0, new Date());
export const reservationStore: Writable<Reservation> = writable<Reservation>(objectReservation);
