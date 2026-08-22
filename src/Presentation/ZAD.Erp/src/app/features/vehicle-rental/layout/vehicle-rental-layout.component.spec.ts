import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleRentalLayoutComponent } from './vehicle-rental-layout.component';

describe('VehicleRentalLayoutComponent', () => {
  let component: VehicleRentalLayoutComponent;
  let fixture: ComponentFixture<VehicleRentalLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehicleRentalLayoutComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicleRentalLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
