import { writable, type Writable } from 'svelte/store';
import { Operation } from '../Enums/operation';
const objectOperation = Operation.List;
export const operationStore: Writable<Operation> = writable<Operation>(objectOperation);
