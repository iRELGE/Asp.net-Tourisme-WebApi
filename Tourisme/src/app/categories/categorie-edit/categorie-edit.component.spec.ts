import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategorieEditComponent } from './categorie-edit.component';

describe('CategorieEditComponent', () => {
  let component: CategorieEditComponent;
  let fixture: ComponentFixture<CategorieEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategorieEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategorieEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
