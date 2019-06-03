import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenaralComponent } from './genaral.component';

describe('GenaralComponent', () => {
  let component: GenaralComponent;
  let fixture: ComponentFixture<GenaralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenaralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenaralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
