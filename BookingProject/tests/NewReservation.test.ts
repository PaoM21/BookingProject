import { render, fireEvent } from '@testing-library/svelte';
import NewReservation from '../src/lib/components/NewReservation.svelte';
import axios from 'axios';
import { vi } from 'vitest';

vi.mock('axios');

describe('NewReservation', () => {
  it('creates a new reservation', async () => {
    axios.post.mockResolvedValueOnce({});

    const { getByLabelText, getByText } = render(NewReservation);
    
    await fireEvent.input(getByLabelText(/Client ID/i), { target: { value: 123 } });
    await fireEvent.input(getByLabelText(/Service ID/i), { target: { value: 456 } });
    await fireEvent.input(getByLabelText(/Reservation Date/i), { target: { value: '2024-10-31T12:00' } });

    await fireEvent.click(getByText(/Crear Reserva/i));

    expect(axios.post).toHaveBeenCalledWith('http://localhost:8080/api/reservations', {
      clientId: 123,
      serviceId: 456,
      reservationDate: '2024-10-31T12:00',
    });
  });
});
