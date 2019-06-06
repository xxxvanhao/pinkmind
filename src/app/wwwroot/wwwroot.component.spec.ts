import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WwwrootComponent } from './wwwroot.component';

describe('WwwrootComponent', () => {
  let component: WwwrootComponent;
  let fixture: ComponentFixture<WwwrootComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WwwrootComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WwwrootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
