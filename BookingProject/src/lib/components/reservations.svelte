<script lang="ts">
  import { onMount } from 'svelte';
  import axios from 'axios';
  let reservations = [];
  let date: string;
  let clientId: number;
  let serviceId: number;

  const fetchReservations = async () => {
    const response = await axios.get('http://localhost:8080/api/reservations', {
      params: { date, clientId, serviceId }
    });
    reservations = response.data;
  };

  onMount(fetchReservations);
</script>

<div>
  <h2>Reservas</h2>
  <input type="date" bind:value={date} on:change={fetchReservations} />
  <input type="number" bind:value={clientId} on:change={fetchReservations} placeholder="Client ID" />
  <input type="number" bind:value={serviceId} on:change={fetchReservations} placeholder="Service ID" />
  
  <ul>
    {#each reservations as reservation}
      <li>Reserva ID: {reservation.id}, Cliente ID: {reservation.clientId}, Servicio ID: {reservation.serviceId}, Fecha: {reservation.reservationDate}</li>
    {/each}
  </ul>
</div>
