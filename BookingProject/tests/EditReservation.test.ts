import { render, fireEvent } from '@testing-library/svelte';
import EditReservation from '../src/lib/components/EditReservation.svelte';
import { reservationStore } from '../src/lib/Store/reservation-store';
import { Operation } from '../src/lib/Enums/operation';
import axios from 'axios';
import { vi } from 'vitest';

vi.mock('axios');

describe('EditReservation', () => {
  let reservationData = { id: 1, clientId: 123, serviceId: 456, reservationDate: new Date() };

  beforeEach(() => {
    reservationStore.set(reservationData);
  });

  it('renders reservation form with correct data', async () => {
    const { getByLabelText } = render(EditReservation);
    
    expect(getByLabelText(/Client ID/i).value).toBe('123');
    expect(getByLabelText(/Service ID/i).value).toBe('456');
  });

  it('submits updated reservation', async () => {
    axios.put.mockResolvedValueOnce({});

    const { getByText } = render(EditReservation);
    const submitButton = getByText(/Actualizar Reserva/i);
    
    await fireEvent.click(submitButton);
    
    expect(axios.put).toHaveBeenCalledWith('http://localhost:8080/api/reservations/1', reservationData);
  });
});
