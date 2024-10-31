<script lang="ts">
  import axios from 'axios';
  export let params;

  const cancelReservation = async () => {
    await axios.delete(`http://localhost:5278/api/reservations/${params.id}`);
    alert('Reserva cancelada!');
  };
</script>

<button on:click={cancelReservation}>Cancelar Reserva</button>
