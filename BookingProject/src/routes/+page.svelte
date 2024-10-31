<script lang="ts">
  import Table from '../lib/components/Table.svelte';
  import EditReservation from '../lib/components/EditReservation.svelte';
  import NewReservation from '../lib/components/NewReservation.svelte';
  import { operationStore } from '../lib/Store/operation-store';
	import { Operation } from '$lib/Enums/operation';

  let operation: Operation;
  operationStore.subscribe((value: Operation) => { operation = value });

</script>

{#if operation == Operation.List }
  <Table />
{/if}

{#if operation == Operation.Update }
  <EditReservation />
{/if}

{#if operation == Operation.Create }
  <NewReservation />
{/if}
