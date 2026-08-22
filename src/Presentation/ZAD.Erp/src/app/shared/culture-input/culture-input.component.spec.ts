import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CultureInputComponent } from './culture-input.component';

describe('CultureInputComponent', () => {
  let component: CultureInputComponent;
  let fixture: ComponentFixture<CultureInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CultureInputComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CultureInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
