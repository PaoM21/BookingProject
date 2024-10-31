<script lang="ts">
	import { operationStore } from '$lib/Store/operation-store';
	import { Operation } from '$lib/Enums/operation';
  import axios from 'axios';
  
  let clientId: number;
  let serviceId: number;
  let reservationDate: string;

  const createReservation = async () => {
    const reservation = { clientId, serviceId, reservationDate };
    await axios.post('http://localhost:8080/api/reservations', reservation);
    alert('Reserva creada!');

    operationStore.set(Operation.List);
  };
</script>

<form on:submit|preventDefault={createReservation}>
  <label>
    Client ID:
    <input type="number" bind:value={clientId} required />
  </label>
  <label>
    Service ID:
    <input type="number" bind:value={serviceId} required />
  </label>
  <label>
    Reservation Date:
    <input type="datetime-local" bind:value={reservationDate} required />
  </label>
  <button type="submit">Crear Reserva</button>
</form>
