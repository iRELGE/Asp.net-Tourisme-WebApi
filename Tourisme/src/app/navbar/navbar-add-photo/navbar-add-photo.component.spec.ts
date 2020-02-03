import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarAddPhotoComponent } from './navbar-add-photo.component';

describe('NavbarAddPhotoComponent', () => {
  let component: NavbarAddPhotoComponent;
  let fixture: ComponentFixture<NavbarAddPhotoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavbarAddPhotoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarAddPhotoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
