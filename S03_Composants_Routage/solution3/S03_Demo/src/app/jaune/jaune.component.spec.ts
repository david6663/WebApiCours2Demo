import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JauneComponent } from './jaune.component';

describe('JauneComponent', () => {
  let component: JauneComponent;
  let fixture: ComponentFixture<JauneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JauneComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JauneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
