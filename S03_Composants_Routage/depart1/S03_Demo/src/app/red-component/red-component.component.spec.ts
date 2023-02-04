import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RedComponentComponent } from './red-component.component';

describe('RedComponentComponent', () => {
  let component: RedComponentComponent;
  let fixture: ComponentFixture<RedComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RedComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RedComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
