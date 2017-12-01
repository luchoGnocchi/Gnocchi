import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BatchTransportComponent } from './batch-transport.component';

describe('BatchTransportComponent', () => {
  let component: BatchTransportComponent;
  let fixture: ComponentFixture<BatchTransportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BatchTransportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BatchTransportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
