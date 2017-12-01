import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewsellComponent } from './viewsell.component';

describe('ViewsellComponent', () => {
  let component: ViewsellComponent;
  let fixture: ComponentFixture<ViewsellComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewsellComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewsellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
