import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleRentalLoginComponent } from './vehicle-rental-login.component';

describe('VehicleRentalLoginComponent', () => {
  let component: VehicleRentalLoginComponent;
  let fixture: ComponentFixture<VehicleRentalLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehicleRentalLoginComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicleRentalLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
