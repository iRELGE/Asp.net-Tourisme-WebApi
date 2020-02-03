import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoriePostComponent } from './categorie-post.component';

describe('CategoriePostComponent', () => {
  let component: CategoriePostComponent;
  let fixture: ComponentFixture<CategoriePostComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoriePostComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoriePostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
