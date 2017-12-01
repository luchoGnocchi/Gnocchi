import { TestBed, async, inject } from '@angular/core/testing';

import { SellVehicleGuard } from './sell-vehicle.guard';

describe('SellVehicleGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SellVehicleGuard]
    });
  });

  it('should ...', inject([SellVehicleGuard], (guard: SellVehicleGuard) => {
    expect(guard).toBeTruthy();
  }));
});
