import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ContractService } from '../../services/contract.service';
import { VehicleRentalContextService } from '../../../shared/services/vehicle-rental-context.service';
import { TenantDropdownDto } from '../../../tenants/models/tenant.model';
import { DropdownDto } from '../../../shared/services/vehicle-rental-lookup.service';
import { ActivatedRoute, Router } from '@angular/router';

import { SweetAlertService } from '@app/core/services/sweet-alert.service';
import { NgSelectModule } from '@ng-select/ng-select';

@Component({
  selector: 'app-update-contract',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, NgSelectModule],
  templateUrl: './update-contract.component.html',
  styleUrl: './update-contract.component.scss'
})
export class UpdateContractComponent implements OnInit {
  form!: FormGroup;
  contractId: number | null = null;
  originalVehicleId: number | null = null;
  activeTab = 'header'; // 'header', 'tenant', 'vehicle'

  tenants: any[] = [];
  drivers: DropdownDto[] = [];
  vehicles: any[] = [];
  sponsors: any[] = [];
  secondDrivers: any[] = [];

  private fb = inject(FormBuilder);
  private contractService = inject(ContractService);
  private contextService = inject(VehicleRentalContextService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private sweetAlert = inject(SweetAlertService);

  ngOnInit(): void {
    this.initForm();
    this.loadDropdowns();

    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.contractId = +id;
        this.loadContract(this.contractId);
      }
    });

    this.setupSubscriptions();
    this.calculateDates();
    this.calculateFields();
  }

  initForm(): void {
    const now = new Date();
    // format to HH:MM for input[type=time]
    const timeString = now.toTimeString().substring(0, 5); 
    // format to YYYY-MM-DD for input[type=date]
    const dateString = now.toISOString().substring(0, 10);

    this.form = this.fb.group({
      // Header
      time: [timeString, Validators.required],
      date: [dateString, Validators.required],
      day: [{value: this.getDayName(dateString), disabled: true}],
      contractType: [1, Validators.required],
      paymentType: [1, Validators.required],
      periodInDays: [1, [Validators.required, Validators.min(1)]],
      actualPeriodInDays: [{value: 0, disabled: true}], // calculated
      expectedReceivingTime: [{value: '', disabled: true}], // calculated
      expectedReceivingDate: [{value: '', disabled: true}], // calculated
      deliveryDay: [{value: '', disabled: true}], // calculated
      withDriver: [false],
      driverId: [{value: null, disabled: true}],

      // Tenant
      tenantId: [null, Validators.required],

      // Sponsor ( Part of Tenant Tab)
      sponsorId: [{value: null, disabled: true}],
      sponsorName: [{value: '', disabled: true}],
      sponsorNationality: [{value: '', disabled: true}],
      sponsorLicenseNumber: [{value: '', disabled: true}],
      sponsorLicenseExpireDate: [{value: '', disabled: true}],
      sponsorIdNumber: [{value: '', disabled: true}],
      sponsorIdExpireDate: [{value: '', disabled: true}],

      // Second Driver
      secondDriverId: [null],
      secondDriverNationality: [''],
      secondDriverLicenseNumber: [''],
      secondDriverLicenseExpireDate: [''],
      secondDriverIdNumber: [''],
      secondDriverIdExpireDate: [''],

      // Vehicle
      rentalVehicleId: [null, Validators.required],
      kilometerCounter: [0, Validators.required],
      rentPrice: [0, [Validators.required, Validators.min(0)]],
      discountPercent: [0, [Validators.required, Validators.min(0), Validators.max(100)]],
      discountAmount: [{value: 0, disabled: true}], //calculated
      netRentPrice: [{value: 0, disabled: true}], //calculated

      // Penalties
      delayPenaltyPerHour: [0, Validators.required],
      allowedDelayHours: [0, Validators.required],
      maintenancePenalty: [0, Validators.required],
      accidentPenalty: [0, Validators.required],

      // Private Driver
      driverFare: [0, Validators.required],
      driverWorkingHoursPerDay: [0, Validators.required],
      driverOvertimeAmountPerHour: [0, Validators.required],
      dailyRate: [{value: 0, disabled: true}], // calculated

      // KM / Day
      // KM / Day
      kilometerPerDay: [0, Validators.required],
      maximumKilometerPerDay: [0, Validators.required],
      amountOfKmExceedingLimit: [0, Validators.required]
    });
  }

  setupSubscriptions(): void {
    this.form.get('discountPercent')?.valueChanges.subscribe(() => {
      this.calculateFields();
    });
    
    this.form.get('driverFare')?.valueChanges.subscribe(() => this.calculateFields());
    this.form.get('driverWorkingHoursPerDay')?.valueChanges.subscribe(() => this.calculateFields());
    this.form.get('driverOvertimeAmountPerHour')?.valueChanges.subscribe(() => this.calculateFields());
    
    // We must subscribe to rentPrice changes to trigger recalculation of discount amount/net price
    this.form.get('rentPrice')?.valueChanges.subscribe(() => this.calculateFields());

    this.form.get('time')?.valueChanges.subscribe(() => {
      this.calculateDates();
    });

    this.form.get('date')?.valueChanges.subscribe(val => {
      if (val) {
        this.form.get('day')?.setValue(this.getDayName(val));
      } else {
        this.form.get('day')?.setValue('');
      }
    });

    this.form.get('withDriver')?.valueChanges.subscribe(val => {
      const driverCtrl = this.form.get('driverId');
      const driverFare = this.form.get('driverFare');
      const driverWorkingHours = this.form.get('driverWorkingHoursPerDay');
      const driverOvertime = this.form.get('driverOvertimeAmountPerHour');
      
      if (val === true || val === 'true') {
        driverCtrl?.enable();
        driverFare?.enable();
        driverWorkingHours?.enable();
        driverOvertime?.enable();
      } else {
        driverCtrl?.disable();
        driverCtrl?.setValue(null);
        
        driverFare?.disable();
        driverWorkingHours?.disable();
        driverOvertime?.disable();
        
        driverFare?.setValue(0);
        driverWorkingHours?.setValue(0);
        driverOvertime?.setValue(0);
      }
    });

    this.form.get('driverId')?.valueChanges.subscribe(val => {
      if (val) {
        // Set realistic driver fares
        this.form.patchValue({
          driverFare: 150.00,
          driverWorkingHoursPerDay: 8.00,
          driverOvertimeAmountPerHour: 25.00
        });
      }
    });

    this.form.get('contractType')?.valueChanges.subscribe(() => {
      this.recalculateRentPrice();
    });

    this.form.get('periodInDays')?.valueChanges.subscribe(() => {
      this.recalculateRentPrice();
    });

    this.form.get('rentalVehicleId')?.valueChanges.subscribe(val => {
      if (val) {
        const vehicle = this.vehicles.find(v => v.id == val);
        if (vehicle) {
          // If the vehicle is rented AND it's NOT the vehicle already attached to THIS contract
          if (vehicle.isRented && vehicle.currentContractId !== this.contractId) {
             import('sweetalert2').then(Swal => {
                Swal.default.fire({
                  icon: 'error',
                  html: `The car cannot be used in the current contract/exit because it is under contract number '${vehicle.currentContractId}', reference no. '${vehicle.currentContractReferenceNo}'. <a style="color: #20c997; cursor: pointer; text-decoration: underline;">View</a>`,
                  confirmButtonColor: '#d33',
                  confirmButtonText: 'Ok'
                });
             });
             this.form.get('rentalVehicleId')?.setValue(this.originalVehicleId || null, { emitEvent: false });
             
             // Restore previous vehicle details or clear
             const originalVehicle = this.originalVehicleId ? this.vehicles.find(v => v.id == this.originalVehicleId) : null;
             if (originalVehicle) {
                 this.form.patchValue({
                    kilometerCounter: originalVehicle.kilometerCounter
                 });
             } else {
                 this.form.patchValue({
                    kilometerPerDay: 0,
                    maximumKilometerPerDay: 0,
                    amountOfKmExceedingLimit: 0,
                    kilometerCounter: 0
                 });
             }
             this.recalculateRentPrice();
             return;
          }
          
          this.form.patchValue({
            kilometerCounter: vehicle.kilometerCounter
          });
          
          // Set realistic KM limits based on vehicle brand/model
          let baseKm = 200;
          let maxKm = 250;
          let exceedAmt = 5.0;

          if (vehicle.brand?.toLowerCase().includes('toyota') || vehicle.brand?.toLowerCase().includes('hyundai') || vehicle.brand?.toLowerCase().includes('kia')) {
            baseKm = 250;
            maxKm = 300;
            exceedAmt = 10.0;
          } else if (vehicle.brand?.toLowerCase().includes('mercedes') || vehicle.brand?.toLowerCase().includes('bmw') || vehicle.brand?.toLowerCase().includes('audi')) {
            baseKm = 150;
            maxKm = 200;
            exceedAmt = 20.0;
          }

          this.form.patchValue({
            kilometerPerDay: baseKm,
            maximumKilometerPerDay: maxKm,
            amountOfKmExceedingLimit: exceedAmt
          });

          this.recalculateRentPrice();
        }
      } else {
         this.form.patchValue({
            kilometerPerDay: 0,
            maximumKilometerPerDay: 0,
            amountOfKmExceedingLimit: 0
         });
      }
    });

    this.form.get('tenantId')?.valueChanges.subscribe(val => {
      const sponsorIdCtrl = this.form.get('sponsorId');
      
      if (val) {
        const tenant = this.tenants.find(t => t.id == val);
        if (tenant) {
          const age = tenant.age;
          if (age < 18 || age > 60) {
            sponsorIdCtrl?.enable();
            sponsorIdCtrl?.setValidators([Validators.required]);
          } else {
            sponsorIdCtrl?.disable();
            sponsorIdCtrl?.clearValidators();
            sponsorIdCtrl?.setValue(null);
          }
          sponsorIdCtrl?.updateValueAndValidity();
        }
      } else {
        sponsorIdCtrl?.disable();
        sponsorIdCtrl?.clearValidators();
        sponsorIdCtrl?.setValue(null);
        sponsorIdCtrl?.updateValueAndValidity();
      }
    });

    this.form.get('sponsorId')?.valueChanges.subscribe(val => {
      if (val) {
        const sponsor = this.sponsors.find(s => s.id == val);
        if (sponsor) {
          this.form.patchValue({
            sponsorName: sponsor.name,
            sponsorNationality: sponsor.nationality,
            sponsorLicenseNumber: sponsor.licenseNumber,
            sponsorLicenseExpireDate: sponsor.licenseExpireDate?.substring(0, 10),
            sponsorIdNumber: sponsor.idNumber,
            sponsorIdExpireDate: sponsor.idExpireDate?.substring(0, 10)
          });
        }
      } else {
        this.form.patchValue({
          sponsorName: '',
          sponsorNationality: '',
          sponsorLicenseNumber: '',
          sponsorLicenseExpireDate: '',
          sponsorIdNumber: '',
          sponsorIdExpireDate: ''
        });
      }
    });

    this.form.get('secondDriverId')?.valueChanges.subscribe(val => {
      if (val) {
        const sd = this.secondDrivers.find(s => s.id == val);
        if (sd) {
          this.form.patchValue({
            secondDriverNationality: sd.nationality,
            secondDriverLicenseNumber: sd.licenseNumber,
            secondDriverLicenseExpireDate: sd.licenseExpireDate?.substring(0, 10),
            secondDriverIdNumber: sd.idNumber,
            secondDriverIdExpireDate: sd.idExpireDate?.substring(0, 10)
          });
        }
      } else {
        this.form.patchValue({
          secondDriverNationality: '',
          secondDriverLicenseNumber: '',
          secondDriverLicenseExpireDate: '',
          secondDriverIdNumber: '',
          secondDriverIdExpireDate: ''
        });
      }
    });
  }

  companies: any[] = [];
  branches: any[] = [];

  loadDropdowns(): void {
    this.contractService.getDropdowns().subscribe(res => {
      this.tenants = res.tenants;
      this.drivers = res.drivers;
      this.vehicles = res.vehicles;
      this.companies = res.companies;
      this.branches = res.branches;
      this.sponsors = res.sponsors || [];
      this.secondDrivers = res.secondDrivers || [];
    });
  }
  
  get selectedTenant(): any {
    const id = this.form.get('tenantId')?.value;
    return id ? this.tenants.find(t => t.id == id) : null;
  }

  selectedTenantLicense(): string {
    return this.selectedTenant?.licenseNumber || '';
  }

  selectedTenantPassport(): string {
    return this.selectedTenant?.passportNumber || '';
  }

  selectedTenantUnified(): string {
    return this.selectedTenant?.unifiedNumber || '';
  }

  selectedTenantId(): string {
    return this.selectedTenant?.idNumber || '';
  }

  selectedTenantMobile(): string {
    return this.selectedTenant?.mobile || '';
  }

  selectedTenantBirthday(): string {
    return this.selectedTenant?.birthday ? this.selectedTenant.birthday.substring(0, 10) : '';
  }

  selectedTenantAge(): string {
    return this.selectedTenant?.age ? this.selectedTenant.age.toString() : '';
  }

  selectedVehicleModelYear(): string {
    const id = this.form.get('rentalVehicleId')?.value;
    if (!id) return '';
    const v = this.vehicles.find(x => x.id == id) as any;
    return v?.modelYear || '';
  }

  getDayName(dateString: string): string {
    if (!dateString) return '';
    const date = new Date(dateString);
    if (isNaN(date.getTime())) return '';
    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    return days[date.getDay()];
  }

  selectedVehicleFileNo(): string {
    const id = this.form.get('rentalVehicleId')?.value;
    if (!id) return '';
    const v = this.vehicles.find(x => x.id == id) as any;
    return v?.fileNo || '';
  }

  loadContract(id: number): void {
    this.contractService.getById(id).subscribe(res => {
      this.originalVehicleId = res.rentalVehicleId;
      this.form.patchValue(res);
    });
  }

  switchTab(tab: string) {
    this.activeTab = tab;
  }

  calculateFields() {
    const rentPrice = this.form.getRawValue().rentPrice || 0;
    const discountPercent = this.form.get('discountPercent')?.value || 0;
    const discountAmount = rentPrice * (discountPercent / 100);
    const netRentPrice = rentPrice - discountAmount;
    
    const driverFare = this.form.get('driverFare')?.value || 0;
    const driverWorkingHours = this.form.get('driverWorkingHoursPerDay')?.value || 0;
    const driverOvertime = this.form.get('driverOvertimeAmountPerHour')?.value || 0;
    const dailyRate = driverFare + (driverWorkingHours * driverOvertime);

    // Update form controls without emitting event to prevent infinite loop
    this.form.get('discountAmount')?.setValue(discountAmount, {emitEvent: false});
    this.form.get('netRentPrice')?.setValue(netRentPrice, {emitEvent: false});
    this.form.get('dailyRate')?.setValue(dailyRate, {emitEvent: false});
    
    this.calculateDates();
  }

  recalculateRentPrice() {
    const vehicleId = this.form.get('rentalVehicleId')?.value;
    const type = +this.form.get('contractType')?.value;
    const period = +this.form.get('periodInDays')?.value || 1;

    // We must always calculate dates/dependent fields regardless of vehicle selection
    this.calculateFields();

    if (!vehicleId || !type) return;

    const vehicle = this.vehicles.find(v => v.id == vehicleId);
    if (!vehicle) return;

    let baseRate = 0;
    switch (type) {
      case 1: baseRate = vehicle.dailyRentPrice; break;
      case 2: baseRate = vehicle.weeklyRentPrice; break;
      case 3: baseRate = vehicle.monthlyRentPrice; break;
      case 4: baseRate = vehicle.yearlyRentPrice; break; // LongTerm maps to YearlyRentPrice
      case 5: baseRate = vehicle.hourlyRentPrice; break;
    }

    const calculatedPrice = baseRate * period;
    
    // We must force the value to update, even if it's disabled
    this.form.get('rentPrice')?.patchValue(calculatedPrice, {emitEvent: true, onlySelf: false});
  }

  getPeriodLabel(): string {
    const type = this.form?.get('contractType')?.value;
    switch (+type) {
      case 1: return 'Period In Days';
      case 2: return 'Period In Weeks';
      case 3: return 'Period In Months';
      case 4: return 'Period In Years';
      case 5: return 'Period In Hours';
      default: return 'Period In Days';
    }
  }

  calculateDates() {
    const type = +this.form.get('contractType')?.value;
    const period = +this.form.get('periodInDays')?.value;
    const dateStr = this.form.get('date')?.value;
    const timeStr = this.form.get('time')?.value;

    if (!dateStr || !timeStr || !period) {
       this.form.patchValue({
         expectedReceivingDate: '',
         expectedReceivingTime: '',
         deliveryDay: '',
         actualPeriodInDays: 0
       }, {emitEvent: false});
       return;
    }

    const [hoursStr, minutesStr] = timeStr.split(':');
    let startDate = new Date(dateStr);
    startDate.setHours(+hoursStr, +minutesStr, 0, 0);

    let expectedDate = new Date(startDate.getTime());
    let actualDays = 0; // Actual Period is always 0 on creation

    switch (type) {
      case 1: // Daily
        expectedDate.setDate(expectedDate.getDate() + period);
        break;
      case 2: // Weekly
        expectedDate.setDate(expectedDate.getDate() + (period * 7));
        break;
      case 3: // Monthly
        expectedDate.setMonth(expectedDate.getMonth() + period);
        break;
      case 4: // Long-term (Years)
        expectedDate.setFullYear(expectedDate.getFullYear() + period);
        break;
      case 5: // Hourly
        expectedDate.setHours(expectedDate.getHours() + period);
        break;
    }

    const year = expectedDate.getFullYear();
    const month = ('0' + (expectedDate.getMonth() + 1)).slice(-2);
    const day = ('0' + expectedDate.getDate()).slice(-2);
    const expectedDateStr = `${year}-${month}-${day}`;

    const outHours = ('0' + expectedDate.getHours()).slice(-2);
    const outMins = ('0' + expectedDate.getMinutes()).slice(-2);
    const expectedTimeStr = `${outHours}:${outMins}`;

    this.form.patchValue({
      expectedReceivingDate: expectedDateStr,
      expectedReceivingTime: expectedTimeStr,
      deliveryDay: this.getDayName(expectedDateStr),
      actualPeriodInDays: actualDays
    }, {emitEvent: false});
  }

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      
      const fieldNames: any = {
        time: 'Time', date: 'Date', contractType: 'Contract Type', paymentType: 'Payment Type',
        periodInDays: 'Period', expectedReceivingTime: 'Expected Receiving Time', expectedReceivingDate: 'Expected Receiving Date',
        tenantId: 'Tenant', sponsorId: 'Sponsor', rentalVehicleId: 'Vehicle Plate No.', kilometerCounter: 'Kilometer Counter',
        rentPrice: 'Rent Price', discountPercent: 'Discount %', delayPenaltyPerHour: 'Delay Penalty Per Hour',
        allowedDelayHours: 'Allowed Delay Hours', maintenancePenalty: 'Maintenance Penalty', accidentPenalty: 'Accident Penalty',
        driverFare: 'Driver Fare', driverWorkingHoursPerDay: 'Driver Working Hours', driverOvertimeAmountPerHour: 'Driver Overtime',
        kilometerPerDay: 'Kilometer Per Day', maximumKilometerPerDay: 'Maximum Kilometer Per Day', amountOfKmExceedingLimit: 'Amount Of Km Exceeding Limit'
      };

      const invalidFields = [];
      const controls = this.form.controls;
      for (const name in controls) {
        if (controls[name].invalid) {
          invalidFields.push(fieldNames[name] || name);
        }
      }

      this.sweetAlert.info('Validation Error', `Please fill the following required fields: ${invalidFields.join(', ')}`);
      return;
    }

    const tenantId = this.form.get('tenantId')?.value;
    const selectedTenant = this.tenants.find(t => t.id === tenantId);
    if (selectedTenant && (selectedTenant.age < 18 || selectedTenant.age > 60)) {
      if (!this.form.get('sponsorId')?.value) {
        this.sweetAlert.error('Warning', 'A Sponsor is required when the tenant age is under 18 or over 60.');
        return;
      }
    }

    const vehicleId = this.form.get('rentalVehicleId')?.value;
    const selectedVehicle = this.vehicles.find(v => v.id === vehicleId);
    if (selectedVehicle) {
      const netRentPrice = this.form.get('netRentPrice')?.value;
      const type = +this.form.get('contractType')?.value;
      const period = +this.form.get('periodInDays')?.value || 1;
      
      let baseRate = 0;
      switch (type) {
        case 1: baseRate = selectedVehicle.dailyRentPrice; break;
        case 2: baseRate = selectedVehicle.weeklyRentPrice; break;
        case 3: baseRate = selectedVehicle.monthlyRentPrice; break;
        case 4: baseRate = selectedVehicle.yearlyRentPrice; break;
        case 5: baseRate = selectedVehicle.hourlyRentPrice; break;
      }
      const expectedMinimum = baseRate * period;

      // if (netRentPrice < expectedMinimum) {
      //   this.sweetAlert.error('Warning', `Net rent price (${netRentPrice}) is lower than the minimum allowed (${expectedMinimum}) for this car and period.`);
      //   return;
      // }
    }

    const dto = this.form.getRawValue();
    const context = this.contextService.getContext();
    dto.companyId = context.companyId;
    dto.branchId = context.branchId;
    // ensure paymentType and withDriver are properly mapped
    dto.paymentType = +dto.paymentType;
    dto.withDriver = dto.withDriver === 'true' || dto.withDriver === true;

    if (dto.sponsorLicenseExpireDate === '') dto.sponsorLicenseExpireDate = null;
    if (dto.sponsorIdExpireDate === '') dto.sponsorIdExpireDate = null;
    if (dto.secondDriverLicenseExpireDate === '') dto.secondDriverLicenseExpireDate = null;
    if (dto.secondDriverIdExpireDate === '') dto.secondDriverIdExpireDate = null;

    if (this.contractId) {
      dto.id = this.contractId;
      this.contractService.update(this.contractId, dto).subscribe({
        next: () => {
          this.sweetAlert.success('Success', 'Contract updated successfully');
          this.router.navigate(['/vehicle-rental/contracts']);
        },
        error: (err) => this.handleError(err, 'Error updating contract')
      });
    }
  }

  private handleError(err: any, defaultMessage: string) {
    console.error('API Error:', err);
    let errorMessage = defaultMessage;
    
    if (err.error) {
      // Check for ASP.NET Core validation errors format
      if (err.error.errors) {
        const validationErrors = [];
        for (const key in err.error.errors) {
          if (err.error.errors.hasOwnProperty(key)) {
            validationErrors.push(`• ${err.error.errors[key].join(', ')}`);
          }
        }
        if (validationErrors.length > 0) {
          errorMessage = validationErrors.join('<br>');
        }
      } 
      // Check for custom message
      else if (err.error.message) {
        errorMessage = err.error.message;
      }
      // Check for plain string
      else if (typeof err.error === 'string') {
        errorMessage = err.error;
      }
    }
    
    this.sweetAlert.error('Error Details', errorMessage);
  }

  cancel() {
    this.router.navigate(['/vehicle-rental/contracts']);
  }
}
