<nav>
  <ul>
    <li><a href="#" on:click={() => navigate('reservation')}>Reservaciones</a></li>
    <li><a href="#" on:click={() => navigate('createReservation')}>Actualizar</a></li>
    <li><a href="#" on:click={() => navigate('updateReservation')}>Editar</a></li>
  </ul>
</nav>

<script>
  import Reservations from '$lib/components/reservations.svelte';
  import CreateReservations from '$lib/components/new-reservation.svelte';
  import EditReservation from '$lib/components/edit-reservation/[id].svelte';
  import CancelReservation from '$lib/components/cancel-reservation/[id].svelte';

  let currentPage = "Reservations";
  function navigate (webPage){
    this.currentPage = webPage;
  }
</script>

  {#if currentPage === 'reservation'}
<Reservations />
    {:else if currentPage === 'createReservation'}
    <CreateReservations />
    {:else if currentPage === 'updateReservation'}
    <EditReservation />
    {:else if currentPage === 'contact'}
    <CancelReservation />
    {/if}


<style>
  nav ul {
    list-style: none;
    padding: 0;
    display: flex;
    gap: 20px;
  }

  nav a {
    text-decoration: none;
    color: #333;
    font-weight: bold;
  }

  nav a:hover {
    color: #007acc;
  }
</style>

