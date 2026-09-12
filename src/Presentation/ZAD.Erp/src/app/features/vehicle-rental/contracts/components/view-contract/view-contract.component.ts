import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ContractService } from '../../services/contract.service';
import { ContractDetailDto } from '../../models/contract.model';
import { SweetAlertService } from '@app/core/services/sweet-alert.service';

import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-view-contract',
  standalone: true,
  imports: [CommonModule, RouterLink, ReactiveFormsModule],
  templateUrl: './view-contract.component.html',
  styleUrl: './view-contract.component.scss'
})
export class ViewContractComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private contractService = inject(ContractService);
  private sweetAlert = inject(SweetAlertService);

  MaintenanceTypes = [
    { value: 1, label: 'Oil Change' },
    { value: 2, label: 'Tire Rotation' },
    { value: 3, label: 'Brake Inspection' },
    { value: 4, label: 'Fluid Check' },
    { value: 5, label: 'Battery Maintenance' },
    { value: 6, label: 'Air Filter Replacement' },
    { value: 7, label: 'Cabin Air Filter Replacement' },
    { value: 8, label: 'Wiper Blade Replacement' },
    { value: 9, label: 'Alignment Check' },
    { value: 10, label: 'Suspension Inspection' },
    { value: 11, label: 'Transmission Service' },
    { value: 12, label: 'Timing Belt Replacement' },
    { value: 13, label: 'Fuel System Cleaning' },
    { value: 14, label: 'Exhaust System Inspection' },
    { value: 15, label: 'Engine Diagnostic' },
    { value: 16, label: 'Cooling System Flush' },
    { value: 17, label: 'Drive Belt Replacement' },
    { value: 18, label: 'Light Bulb Replacement' },
    { value: 19, label: 'Safety Inspection' },
    { value: 20, label: 'Regular Wash & Wax' }
  ];
  contract: ContractDetailDto | null = null;
  activeTab = 'tenant';
  loading = true;
  contractId: number | null = null;
  tenants: any[] = [];

  receiveForm!: FormGroup;
  vehicleReceivingStatuses = [
    { value: 1, label: 'Pending Inspection' },
    { value: 2, label: 'Under Inspection' },
    { value: 3, label: 'Damaged' },
    { value: 4, label: 'Cleaned' },
    { value: 5, label: 'In Repair' },
    { value: 6, label: 'Ready for Rental' },
    { value: 7, label: 'Needs Cleaning' },
    { value: 8, label: 'Unclean' },
    { value: 9, label: 'Rented' }
  ];
  private fb = inject(FormBuilder);

  ngOnInit(): void {
    this.initReceiveForm();
    this.route.paramMap.subscribe(params => {
      const idStr = params.get('id');
      if (idStr) {
        this.contractId = +idStr;
        this.loadContract(this.contractId);
      }
    });

    this.contractService.getDropdowns().subscribe(res => {
      this.tenants = res.tenants;
    });
  }

  initReceiveForm(): void {
    const now = new Date();
    this.receiveForm = this.fb.group({
      receivingDate: [now.toISOString().split('T')[0], Validators.required],
      receivingTime: [now.toTimeString().slice(0, 5), Validators.required],
      receivingKilometerCounter: [0, [Validators.required, Validators.min(0)]],
      receiveProofDocuments: [true],
      receiveNotes: [''],
      accidentPenaltyAmount: [0, Validators.min(0)],
      maintenancePaidByTenant: [0, Validators.min(0)],
      receiveDiscountAmount: [0, Validators.min(0)],
      isMaintenanceDoneByTenant: [false],
      maintenanceType: [null],
      maintenanceDate: [''],
      maintenanceKM: [null, Validators.min(0)],
      maintenanceNote: [''],
      nextMaintenanceDate: [''],
      nextMaintenanceKM: [null, Validators.min(0)],
      vehicleReceivingStatus: [null, Validators.required],
      isVehicleStoppedUntilMaintenanceOrRepair: [false],
      damageNote: ['']
    });

    this.receiveForm.get('isMaintenanceDoneByTenant')?.valueChanges.subscribe(val => {
      const typeCtrl = this.receiveForm.get('maintenanceType');
      if (val) {
        typeCtrl?.setValidators([Validators.required]);
      } else {
        typeCtrl?.clearValidators();
      }
      typeCtrl?.updateValueAndValidity();
    });
  }

  loadContract(id: number): void {
    this.loading = true;
    this.contractService.getById(id).subscribe({
      next: (data) => {
        this.contract = data;
        this.loading = false;
        
        // Auto-fill renting kilometer counter if available
        if (this.contract && this.contract.kilometerCounter) {
          this.receiveForm.patchValue({
            receivingKilometerCounter: this.contract.kilometerCounter
          });
        }
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
        this.sweetAlert.error('Error', 'Failed to load contract details.');
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/vehicle-rental/contracts']);
  }

  switchTab(tab: string): void {
    this.activeTab = tab;
  }

  //   ─ Computed Receive Values ─
  get recActualPeriodInDays(): number {
    if (!this.contract) return 0;
    const rentDate = new Date(this.contract.date);
    const recDate = new Date(this.receiveForm.value.receivingDate);
    const diffTime = recDate.getTime() - rentDate.getTime();
    let days = Math.max(0, Math.floor(diffTime / (1000 * 60 * 60 * 24)));
    return days;
  }

  get recDelayHours(): number {
    if (!this.contract) return 0;
    const rentDate = new Date(this.contract.date);
    const expDate = new Date(rentDate.getTime() + this.contract.periodInDays * 24 * 60 * 60 * 1000);
    // Add expected receiving time
    const [expH, expM] = this.contract.expectedReceivingTime.split(':');
    expDate.setHours(+expH, +expM, 0);

    const recDate = new Date(this.receiveForm.value.receivingDate);
    const [recH, recM] = this.receiveForm.value.receivingTime.split(':');
    recDate.setHours(+recH, +recM, 0);

    const diffHours = (recDate.getTime() - expDate.getTime()) / (1000 * 60 * 60);
    const allowed = this.contract.allowedDelayHours || 0;
    return diffHours > allowed ? Math.floor(diffHours - allowed) : 0;
  }

  get recTotalConsumptionKm(): number {
    if (!this.contract) return 0;
    const receiving = this.receiveForm.value.receivingKilometerCounter || 0;
    const renting = this.contract.kilometerCounter || 0;
    return receiving - renting;
  }

  get recAvgKmPerDay(): number {
    const period = this.recActualPeriodInDays;
    if (period === 0) return 0;
    return this.recTotalConsumptionKm / period;
  }

  get recFreeKm(): number {
    if (!this.contract) return 0;
    return this.recActualPeriodInDays * (this.contract.kilometerPerDay || 0);
  }

  get recKmExceeded(): number {
    return Math.max(0, this.recTotalConsumptionKm - this.recFreeKm);
  }

  get recKmExceededAmount(): number {
    if (!this.contract) return 0;
    return this.recKmExceeded * (this.contract.amountOfKmExceedingLimit || 0);
  }

  get recDelayPenalty(): number {
    if (!this.contract) return 0;
    return this.recDelayHours * (this.contract.delayPenaltyPerHour || 0);
  }

  get recTotalRentalAmount(): number {
    if (!this.contract) return 0;
    return this.recActualPeriodInDays * (this.contract.netRentPrice || 0);
  }

  get recMaintenancePenalty(): number {
    if (!this.contract) return 0;
    const recDate = new Date(this.receiveForm.value.receivingDate);
    const recKM = this.receiveForm.value.receivingKilometerCounter || 0;
    
    let isPenalty = false;
    if (this.contract.contractNextMaintenanceDate) {
       if (recDate > new Date(this.contract.contractNextMaintenanceDate)) {
           isPenalty = true;
       }
    }
    if (this.contract.contractNextMaintenanceKM && this.contract.contractNextMaintenanceKM > 0) {
       if (recKM >= this.contract.contractNextMaintenanceKM) {
           isPenalty = true;
       }
    }
    
    return isPenalty ? (this.contract.maintenancePenalty || 0) : 0;
  }

  get recTotalDriverAmount(): number {
    if (!this.contract || !this.contract.withDriver) return 0;
    return this.recActualPeriodInDays * (this.contract.driverFare || 0);
  }

  get recTotalDueAmount(): number {
    const rental = this.recTotalRentalAmount;
    const driver = this.recTotalDriverAmount;
    const kmPenalty = this.recKmExceededAmount;
    const delayPenalty = this.recDelayPenalty;
    const maintPenalty = this.recMaintenancePenalty;
    const accPenalty = this.receiveForm.value.accidentPenaltyAmount || 0;
    const maintPaid = this.receiveForm.value.maintenancePaidByTenant || 0;
    
    return rental + driver + kmPenalty + delayPenalty + maintPenalty + accPenalty - maintPaid;
  }

  get recNetDueAmount(): number {
    const discount = this.receiveForm.value.receiveDiscountAmount || 0;
    return this.recTotalDueAmount - discount;
  }

  //   ─ Status helpers
  get isConfirmed(): boolean { return this.contract?.status === 'Confirmed'; }
  get isDraft(): boolean { return this.contract?.status === 'Draft'; }
  get isDeleted(): boolean { return this.contract?.status === 'Deleted'; }
  get isVehicleReceived(): boolean { return this.contract?.deliveryStatus === 'Delivered'; }

  get statusClass(): string {
    switch (this.contract?.status) {
      case 'Confirmed': return 'text-success';
      case 'Draft': return 'text-secondary';
      case 'Canceled': return 'text-danger';
      case 'Deleted': return 'text-dark';
      case 'Closed': return 'text-info';
      default: return 'text-secondary';
    }
  }

  get selectedTenant(): any {
    return this.contract?.tenantId ? this.tenants.find(t => t.id == this.contract?.tenantId) : null;
  }
  selectedTenantLicense(): string { return this.selectedTenant?.licenseNumber || ''; }
  selectedTenantPassport(): string { return this.selectedTenant?.passportNumber || ''; }
  selectedTenantUnified(): string { return this.selectedTenant?.unifiedNumber || ''; }
  selectedTenantId(): string { return this.selectedTenant?.idNumber || ''; }
  selectedTenantMobile(): string { return this.selectedTenant?.mobile || ''; }
  selectedTenantBirthday(): string { return this.selectedTenant?.birthday ? this.selectedTenant.birthday.substring(0, 10) : ''; }
  selectedTenantAge(): string { return this.selectedTenant?.age ? this.selectedTenant.age.toString() : ''; }

  //   ─ Actions          ─
  async onConfirm(): Promise<void> {
    if (!this.contractId) return;
    const ok = await this.sweetAlert.confirm('Confirm Contract', 'Are you sure?');
    if (!ok) return;
    this.contractService.confirm(this.contractId).subscribe({
      next: () => { this.sweetAlert.success('Confirmed!'); this.loadContract(this.contractId!); },
      error: (err) => this.sweetAlert.error('Error', this.getErrorMessage(err))
    });
  }

  async onUnconfirm(): Promise<void> {
    if (!this.contractId) return;
    const ok = await this.sweetAlert.confirm('Unconfirm Contract', 'Unconfirm this contract?');
    if (!ok) return;
    this.contractService.unconfirm(this.contractId).subscribe({
      next: () => { this.sweetAlert.success('Unconfirmed!'); this.loadContract(this.contractId!); },
      error: (err) => this.sweetAlert.error('Error', this.getErrorMessage(err))
    });
  }

  goToReceiveTab(): void {
    this.activeTab = 'receive';
  }

  async onReceiveVehicle(): Promise<void> {
    if (!this.contractId) return;
    if (this.receiveForm.invalid) {
      this.receiveForm.markAllAsTouched();
      this.sweetAlert.error('Validation Error', 'Please check the required fields (highlighted in red).');
      return;
    }
    
    if (this.recTotalConsumptionKm < 0) {
      this.sweetAlert.error('Validation Error', "'Total Kilo Meters Consumption' must be greater than or equal to '0'.\n'Average Kilo Meters Per Day' must be greater than or equal to '0'.");
      return;
    }
    
    const payload = { ...this.receiveForm.value };
    payload.receiveDiscountAmount = Number(payload.receiveDiscountAmount) || 0;
    payload.accidentPenaltyAmount = Number(payload.accidentPenaltyAmount) || 0;
    payload.maintenancePaidByTenant = Number(payload.maintenancePaidByTenant) || 0;
    payload.receivingKilometerCounter = Number(payload.receivingKilometerCounter) || 0;
    payload.maintenanceDate = payload.maintenanceDate || null;
    payload.nextMaintenanceDate = payload.nextMaintenanceDate || null;
    
    const ok = await this.sweetAlert.confirm('Receive Vehicle', 'Confirm vehicle receipt and close contract?');
    if (!ok) return;
    this.contractService.receiveVehicle(this.contractId, payload).subscribe({
      next: () => {
        this.sweetAlert.success('Receive details saved!');
        this.loadContract(this.contractId!); // Reload view, status remains Rented/Late
      },
      error: (err) => this.sweetAlert.error('Error', this.getErrorMessage(err))
    });
  }

  async onConfirmReceiveVehicle(): Promise<void> {
    if (!this.contractId) return;
    const ok = await this.sweetAlert.confirm('Confirm Receive Vehicle', 'Are you sure you want to finalize and receive the vehicle?');
    if (!ok) return;
    this.contractService.confirmReceiveVehicle(this.contractId).subscribe({
      next: () => { 
        this.sweetAlert.success('Vehicle Received Successfully!');
        this.router.navigate(['/vehicle-rental/contracts']);
      },
      error: (err) => this.sweetAlert.error('Error', this.getErrorMessage(err))
    });
  }

  async onUnreceiveVehicle(): Promise<void> {
    if (!this.contractId) return;
    const ok = await this.sweetAlert.confirm('Unconfirm Receive Vehicle', 'Are you sure you want to unconfirm vehicle receipt?');
    if (!ok) return;
    this.contractService.unreceiveVehicle(this.contractId).subscribe({
      next: () => { this.sweetAlert.success('Vehicle Receipt Unconfirmed!'); this.loadContract(this.contractId!); },
      error: (err) => this.sweetAlert.error('Error', this.getErrorMessage(err))
    });
  }

  async onDelete(): Promise<void> {
    if (!this.contractId) return;
    const ok = await this.sweetAlert.confirm('Delete Contract', 'Are you sure you want to delete this contract?');
    if (!ok) return;
    this.contractService.delete(this.contractId).subscribe({
      next: () => { this.sweetAlert.success('Deleted!'); this.router.navigate(['/vehicle-rental/contracts']); },
      error: (err) => this.sweetAlert.error('Error', this.getErrorMessage(err))
    });
  }

  async onRestore(): Promise<void> {
    if (!this.contractId) return;
    const ok = await this.sweetAlert.confirm('Restore Contract', 'Restore this contract?');
    if (!ok) return;
    this.contractService.restore(this.contractId).subscribe({
      next: () => { this.sweetAlert.success('Restored!'); this.loadContract(this.contractId!); },
      error: (err) => this.sweetAlert.error('Error', this.getErrorMessage(err))
    });
  }


  formatTime(ts: string): string {
    if (!ts) return '';
    const parts = ts.split(':');
    if (parts.length < 2) return ts;
    const h = +parts[0];
    const m = parts[1];
    const ampm = h >= 12 ? 'PM' : 'AM';
    const h12 = h % 12 === 0 ? 12 : h % 12;
    return `${h12}:${m} ${ampm}`;
  }

  private getErrorMessage(err: any): string {
    if (err?.error?.message) return err.error.message;
    if (err?.error?.errors) {
      return Object.values(err.error.errors).flat().join('\n');
    }
    if (typeof err?.error === 'string') return err.error;
    return err?.message || 'Failed';
  }
}
