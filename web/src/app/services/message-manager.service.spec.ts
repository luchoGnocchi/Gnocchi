import { TestBed, inject } from '@angular/core/testing';

import { MessageManagerService } from './message-manager.service';

describe('MessageManagerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MessageManagerService]
    });
  });

  it('should be created', inject([MessageManagerService], (service: MessageManagerService) => {
    expect(service).toBeTruthy();
  }));
});
