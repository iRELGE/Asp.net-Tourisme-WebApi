import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewhostelsComponent } from './newhostels.component';

describe('NewhostelsComponent', () => {
  let component: NewhostelsComponent;
  let fixture: ComponentFixture<NewhostelsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewhostelsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewhostelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
