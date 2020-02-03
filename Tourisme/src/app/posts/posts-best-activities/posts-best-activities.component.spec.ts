import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PostsBestActivitiesComponent } from './posts-best-activities.component';

describe('PostsBestActivitiesComponent', () => {
  let component: PostsBestActivitiesComponent;
  let fixture: ComponentFixture<PostsBestActivitiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PostsBestActivitiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PostsBestActivitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
