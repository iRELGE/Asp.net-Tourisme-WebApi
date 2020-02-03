import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarListPhotoComponent } from './navbar-list-photo.component';

describe('NavbarListPhotoComponent', () => {
  let component: NavbarListPhotoComponent;
  let fixture: ComponentFixture<NavbarListPhotoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavbarListPhotoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarListPhotoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
