import { TestBed, async, inject } from '@angular/core/testing';

import { VehiclesGuard } from './vehicles.guard';

describe('VehiclesGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VehiclesGuard]
    });
  });

  it('should ...', inject([VehiclesGuard], (guard: VehiclesGuard) => {
    expect(guard).toBeTruthy();
  }));
});
