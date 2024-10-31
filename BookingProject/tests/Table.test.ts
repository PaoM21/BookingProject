import { render, fireEvent } from '@testing-library/svelte';
import Table from '../src/lib/components/Table.svelte';
import axios from 'axios';
import { vi } from 'vitest';
import { reservationStore } from '../src/lib/Store/reservation-store';

vi.mock('axios');

describe('Table', () => {
  beforeEach(() => {
    reservationStore.set([]);
  });

  it('fetches and displays reservations', async () => {
    const reservations = [{ id: 1, clientId: 123, serviceId: 456, reservationDate: new Date() }];
    axios.get.mockResolvedValueOnce({ data: reservations });

    const { getByText } = render(Table);
    
    // Wait for reservations to be displayed
    expect(await getByText(/Client ID/i)).toBeTruthy();
    expect(await getByText(/123/i)).toBeTruthy();
  });

  it('cancels a reservation', async () => {
    const reservations = [{ id: 1, clientId: 123, serviceId: 456, reservationDate: new Date() }];
    axios.get.mockResolvedValueOnce({ data: reservations });
    axios.delete.mockResolvedValueOnce({});

    const { getByText } = render(Table);
    
    await fireEvent.click(getByText(/Eliminar/i));

    expect(axios.delete).toHaveBeenCalledWith('http://localhost:8080/api/reservations/1');
  });
});
