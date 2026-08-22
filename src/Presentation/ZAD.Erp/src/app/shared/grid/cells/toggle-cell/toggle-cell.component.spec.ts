import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToggleCellComponent } from './toggle-cell.component';

describe('ToggleCellComponent', () => {
  let component: ToggleCellComponent;
  let fixture: ComponentFixture<ToggleCellComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ToggleCellComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToggleCellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
