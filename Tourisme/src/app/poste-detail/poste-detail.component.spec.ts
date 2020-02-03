import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PosteDetailComponent } from './poste-detail.component';

describe('PosteDetailComponent', () => {
  let component: PosteDetailComponent;
  let fixture: ComponentFixture<PosteDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PosteDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PosteDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
