<script lang="ts">
  import { onMount } from 'svelte';
  import axios from 'axios';
  export let params;
  let reservation;

  onMount(async () => {
    const response = await axios.get(`http://localhost:5278/api/reservations/${params.id}`);
    reservation = response.data;
  });

  const updateReservation = async () => {
    await axios.put(`http://localhost:5278/api/reservations/${reservation.id}`, reservation);
    alert('Reserva actualizada!');
  };
</script>

<form on:submit|preventDefault={updateReservation}>
  <label>
    Client ID:
    <input type="number" bind:value={reservation?.clientId} required />
  </label>
  <label>
    Service ID:
    <input type="number" bind:value={reservation?.serviceId} required />
  </label>
  <label>
    Reservation Date:
    <input type="datetime-local" bind:value={reservation?.reservationDate} required />
  </label>
  <button type="submit">Actualizar Reserva</button>
</form>
