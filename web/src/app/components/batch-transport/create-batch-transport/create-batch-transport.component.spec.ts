import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBatchTransportComponent } from './create-batch-transport.component';

describe('CreateBatchTransportComponent', () => {
  let component: CreateBatchTransportComponent;
  let fixture: ComponentFixture<CreateBatchTransportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CreateBatchTransportComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBatchTransportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
