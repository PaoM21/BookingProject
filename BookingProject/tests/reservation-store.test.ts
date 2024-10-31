import { reservationStore } from '../src/lib/Store/reservation-store';
import { Reservation } from '../src/lib/Model/booking-entity';

describe('Reservation Store', () => {
  it('initializes with a blank reservation', () => {
    reservationStore.subscribe(value => {
      expect(value).toEqual(new Reservation(0, 0, 0, new Date()));
    });
  });

  it('sets reservation correctly', () => {
    const newReservation = new Reservation(1, 123, 456, new Date());
    reservationStore.set(newReservation);
    reservationStore.subscribe(value => {
      expect(value).toEqual(newReservation);
    });
  });
});
