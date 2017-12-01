import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BatchsComponent } from './batchs.component';

describe('BatchsComponent', () => {
  let component: BatchsComponent;
  let fixture: ComponentFixture<BatchsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BatchsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BatchsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
