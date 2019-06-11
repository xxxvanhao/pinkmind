import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProFileComponent } from './pro-file.component';

describe('ProFileComponent', () => {
  let component: ProFileComponent;
  let fixture: ComponentFixture<ProFileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProFileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
