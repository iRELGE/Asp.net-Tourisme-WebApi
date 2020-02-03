import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostsBestPlaceToTravelComponent } from './posts-best-place-to-travel.component';

describe('PostsBestPlaceToTravelComponent', () => {
  let component: PostsBestPlaceToTravelComponent;
  let fixture: ComponentFixture<PostsBestPlaceToTravelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostsBestPlaceToTravelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostsBestPlaceToTravelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
