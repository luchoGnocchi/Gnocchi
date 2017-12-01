import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatesellComponent } from './createsell.component';

describe('CreatesellComponent', () => {
  let component: CreatesellComponent;
  let fixture: ComponentFixture<CreatesellComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatesellComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatesellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
