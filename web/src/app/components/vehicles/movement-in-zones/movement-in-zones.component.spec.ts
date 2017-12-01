import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MovementInZonesComponent } from './movement-in-zones.component';

describe('MovementInZonesComponent', () => {
  let component: MovementInZonesComponent;
  let fixture: ComponentFixture<MovementInZonesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MovementInZonesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MovementInZonesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
