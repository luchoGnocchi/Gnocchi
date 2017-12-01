import { TestBed, async, inject } from '@angular/core/testing';

import { BatchTransportGuard } from './batch-transport.guard';

describe('BatchTransportGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BatchTransportGuard]
    });
  });

  it('should ...', inject([BatchTransportGuard], (guard: BatchTransportGuard) => {
    expect(guard).toBeTruthy();
  }));
});
