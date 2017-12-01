import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDamageComponent } from './add-damage.component';

describe('AddDamageComponent', () => {
  let component: AddDamageComponent;
  let fixture: ComponentFixture<AddDamageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddDamageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDamageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
