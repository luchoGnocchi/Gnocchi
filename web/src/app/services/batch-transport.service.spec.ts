import { TestBed, inject } from '@angular/core/testing';

import { BatchTransportService } from './batch-transport.service';

describe('BatchTransportService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BatchTransportService]
    });
  });

  it('should be created', inject([BatchTransportService], (service: BatchTransportService) => {
    expect(service).toBeTruthy();
  }));
});
