<script lang="ts">
  import { onMount } from 'svelte';
  import axios from 'axios';
  import { reservationStore } from "../Store/reservation-store"
  import { operationStore } from "../Store/operation-store"
	import type { Reservation } from '$lib/Model/booking-entity';
	import { Operation } from '$lib/Enums/operation';

  let reservations: Reservation[] = [];  
  let columns = ['id', 'clientId', 'serviceId', 'reservationDate'];
  
  const fetchReservations = async () => {
    const response = await axios.get('http://localhost:8080/api/reservations');
    reservations = response.data;
  };

  onMount(fetchReservations);

  const cancelReservation = async (id: number) => {
    await axios.delete(`http://localhost:8080/api/reservations/${id}`);
    alert('Reserva cancelada!');

    (fetchReservations());
  };

  function setInformation(data: Reservation){
    reservationStore.set(data);
    operationStore.set(Operation.Update);
  }

  function createReservation() {
    operationStore.set(Operation.Create);
  }
</script>

{#if reservations.length > 0 }
  <table>
    <thead>
      <tr>
        <th>Id</th>
        <th>clientId</th>
        <th>ServiceId</th>
        <th>ReservationDate</th>
        <th>Acciones</th>
      </tr>
    </thead>
    <tbody>
      {#each reservations as row}
        <tr>
          <td>{ row.id}</td>
          <td>{ row.clientId }</td>
          <td>{ row.serviceId }</td>
          <td>{ row.reservationDate }</td>
          <td>
            <button on:click={ () => setInformation(row) }>Editar</button>
            <button on:click={ () => cancelReservation(row.id) }>Eliminar</button>
          </td>
        </tr>
      {/each}
    </tbody>
  </table>
{:else}
  <p>No hay reservas disponibles.</p>
{/if}

<button on:click={ createReservation }>Agregar Reserva</button>