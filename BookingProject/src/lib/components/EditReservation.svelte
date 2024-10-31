<script lang="ts">
  import axios from 'axios';
  import { onMount } from 'svelte';
  import { reservationStore } from '../Store/reservation-store'
	import { Reservation } from '$lib/Model/booking-entity';
	import { Operation } from '$lib/Enums/operation';
	import { operationStore } from '$lib/Store/operation-store';

  let reservation : Reservation;

  onMount(async () => {
    const response = await axios.get(`http://localhost:8080/api/reservations/${reservation.id}`);
    reservation = response.data;
  });

  const updateReservation = async () => {
    await axios.put(`http://localhost:8080/api/reservations/${reservation.id}`, reservation);
    alert('Reserva actualizada!');

    operationStore.set(Operation.List);
  };

  reservationStore.subscribe((value: Reservation) => { reservation = value });
</script>

<form on:submit|preventDefault={updateReservation}>
  <label>
    Client ID:
    <input type="number" bind:value={reservation.clientId} required />
  </label>
  <label>
    Service ID:
    <input type="number" bind:value={reservation.serviceId} required />
  </label>
  <label>
    Reservation Date:
    <input type="datetime-local" bind:value={reservation.reservationDate} required />
  </label>
  <button type="submit">Actualizar Reserva</button>
</form>
