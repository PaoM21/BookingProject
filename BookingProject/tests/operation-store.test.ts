import { operationStore } from '../src/lib/Store/operation-store';
import { Operation } from '../src/lib/Enums/operation';

describe('Operation Store', () => {
  it('initializes with List operation', () => {
    operationStore.subscribe(value => {
      expect(value).toBe(Operation.List);
    });
  });

  it('sets operation correctly', () => {
    operationStore.set(Operation.Update);
    operationStore.subscribe(value => {
      expect(value).toBe(Operation.Update);
    });
  });
});
