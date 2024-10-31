<script lang="ts">
  import axios from 'axios';
  let clientId: number;
  let serviceId: number;
  let reservationDate: string;

  const createReservation = async () => {
    const reservation = { clientId, serviceId, reservationDate };
    await axios.post('http://localhost:5278/api/reservations', reservation);
    alert('Reserva creada!');
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
