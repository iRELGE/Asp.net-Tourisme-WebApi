import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopcountryComponent } from './topcountry.component';

describe('TopcountryComponent', () => {
  let component: TopcountryComponent;
  let fixture: ComponentFixture<TopcountryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopcountryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopcountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
