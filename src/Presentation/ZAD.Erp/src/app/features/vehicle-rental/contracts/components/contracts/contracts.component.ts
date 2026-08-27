import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ContractService } from '../../services/contract.service';
import { SweetAlertService } from '@app/core/services/sweet-alert.service';
import { VehicleRentalContextService, VehicleRentalContext } from '../../../shared/services/vehicle-rental-context.service';

type SortField = 'accountingNo' | 'plateNo' | 'brand' | 'date' | 'toDate' | 'periodInDays' | 'actualPeriodInDays' | 'contractType' | 'tenantName' | 'remainingAmount' | 'deliveryStatus' | 'status';
type SortDir = 'asc' | 'desc' | null;

@Component({
  selector: 'app-contracts',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './contracts.component.html',
  styleUrl: './contracts.component.scss'
})
export class ContractsComponent implements OnInit {
  private contractService = inject(ContractService);
  private sweetAlert = inject(SweetAlertService);
  private contextService = inject(VehicleRentalContextService);
  private router = inject(Router);

  context: VehicleRentalContext | null = null;

  allContracts: any[] = [];
  contracts: any[] = [];
  pageNumber = 1;
  pageSize = 10;
  totalCount = 0;

  searchTerm = '';
  sortField: SortField | null = null;
  sortDir: SortDir = null;

  selectedIds: Set<number> = new Set();

  ngOnInit(): void {
    this.contextService.context$.subscribe(ctx => {
      this.context = ctx;
    });
    this.loadContracts();
  }

  changeContext() {
    this.contextService.clearContext();
    this.router.navigate(['/account/login/company']);
  }

  loadContracts(): void {
    this.contractService.getPage({ pageNumber: 1, pageSize: 9999 }).subscribe({
      next: (result) => {
        this.allContracts = result.items;
        this.totalCount = result.totalCount;
        this.applyFilter();
      },
      error: (err: any) => console.error(err)
    });
  }

  applyFilter(): void {
    const term = this.searchTerm.toLowerCase().trim();
    let filtered = this.allContracts;

    if (this.context?.companyId) {
      filtered = filtered.filter(c => c.companyId == this.context?.companyId);
    }
    if (this.context?.branchId) {
      filtered = filtered.filter(c => c.branchId == this.context?.branchId);
    }

    if (term) {
      filtered = filtered.filter(c =>
        (c.accountingNo?.toString() || '').includes(term) ||
        (c.plateNo?.toLowerCase() || '').includes(term) ||
        (c.brand?.toLowerCase() || '').includes(term) ||
        (c.tenantName?.toLowerCase() || '').includes(term) ||
        (c.status?.toLowerCase() || '').includes(term)
      );
    }

    if (this.sortField && this.sortDir) {
      const field = this.sortField;
      const dir = this.sortDir === 'asc' ? 1 : -1;
      filtered = [...filtered].sort((a, b) => {
        const av = (a[field] || '').toString().toLowerCase();
        const bv = (b[field] || '').toString().toLowerCase();
        return av < bv ? -dir : av > bv ? dir : 0;
      });
    }

    this.contracts = filtered;
  }

  onSearch(): void {
    this.applyFilter();
  }

  toggleSort(field: SortField): void {
    if (this.sortField === field) {
      if (this.sortDir === 'asc') this.sortDir = 'desc';
      else if (this.sortDir === 'desc') { this.sortDir = null; this.sortField = null; }
    } else {
      this.sortField = field;
      this.sortDir = 'asc';
    }
    this.applyFilter();
  }

  getSortIcon(field: SortField): string {
    if (this.sortField !== field) return 'fas fa-sort text-muted';
    if (this.sortDir === 'asc') return 'fas fa-sort-amount-up text-teal';
    return 'fas fa-sort-amount-down-alt text-teal';
  }

  //   ─ Selection            ─
  toggleSelect(id: number): void {
    if (this.selectedIds.has(id)) this.selectedIds.delete(id);
    else this.selectedIds.add(id);
  }

  isSelected(id: number): boolean {
    return this.selectedIds.has(id);
  }

  toggleSelectAll(event: Event): void {
    const checked = (event.target as HTMLInputElement).checked;
    if (checked) {
      this.contracts.forEach(c => this.selectedIds.add(c.id));
    } else {
      this.selectedIds.clear();
    }
  }

  get allSelected(): boolean {
    return this.contracts.length > 0 && this.contracts.every(c => this.selectedIds.has(c.id));
  }

  //   ─ Status helpers        ─
  isConfirmed(contract: any): boolean {
    return contract.status === 'Confirmed';
  }

  isDraft(contract: any): boolean {
    return contract.status === 'Draft';
  }

  isDeleted(contract: any): boolean {
    return contract.status === 'Deleted';
  }

  getDeliveryStatusClass(status: string): string {
    switch (status) {
      case 'Rented': return 'badge-delivery-rented';
      case 'LateThanExpected': return 'badge-delivery-late';
      case 'Delivered': return 'badge-delivery-delivered';
      default: return 'badge bg-secondary';
    }
  }

  getDeliveryStatusLabel(status: string): string {
    switch (status) {
      case 'Rented': return 'Rented';
      case 'LateThanExpected': return 'Late Than Expected';
      case 'Delivered': return 'Delivered';
      default: return status;
    }
  }

  getStatusClass(status: string): string {
    switch (status) {
      case 'Confirmed': return 'text-success fw-semibold';
      case 'Draft': return 'text-secondary fw-semibold';
      case 'Deleted': return 'text-danger fw-semibold';
      default: return '';
    }
  }

  //   ─ Actions      
  async deleteContract(id: number) {
    const confirmed = await this.sweetAlert.confirm('Confirm', 'Are you sure you want to delete this contract?');
    if (confirmed) {
      this.contractService.delete(id).subscribe({
        next: () => {
          this.sweetAlert.success('Contract deleted successfully');
          this.loadContracts();
        },
        error: (err: any) => {
          const msg = err?.error?.message || 'Failed to delete contract';
          this.sweetAlert.error('Error', msg);
        }
      });
    }
  }

  async restoreContract(id: number) {
    const confirmed = await this.sweetAlert.confirm('Restore', 'Restore this contract?');
    if (confirmed) {
      this.contractService.restore(id).subscribe({
        next: () => {
          this.sweetAlert.success('Contract restored successfully');
          this.loadContracts();
        },
        error: (err: any) => {
          const msg = err?.error?.message || 'Failed to restore contract';
          this.sweetAlert.error('Error', msg);
        }
      });
    }
  }

  async confirmContract(id: number) {
    const confirmed = await this.sweetAlert.confirm('Confirm Contract', 'Are you sure you want to confirm this contract?');
    if (confirmed) {
      this.contractService.confirm(id).subscribe({
        next: () => {
          this.sweetAlert.success('Contract confirmed successfully');
          this.loadContracts();
        },
        error: (err: any) => {
          const msg = err?.error?.message || 'Failed to confirm contract';
          this.sweetAlert.error('Error', msg);
        }
      });
    }
  }

  async unconfirmContract(id: number): Promise<void> {
    const ok = await this.sweetAlert.confirm('Unconfirm Contract', 'Are you sure you want to unconfirm this contract?');
    if (!ok) return;

    this.contractService.unconfirm(id).subscribe({
      next: () => {
        this.sweetAlert.success('Contract unconfirmed successfully');
        this.loadContracts();
      },
      error: (err) => this.sweetAlert.error('Error', err?.error?.message || 'Failed to unconfirm contract')
    });
  }


  async unreceiveVehicle(id: number): Promise<void> {
    const ok = await this.sweetAlert.confirm('Unconfirm Receive Vehicle', 'Are you sure you want to unconfirm vehicle receipt?');
    if (!ok) return;

    this.contractService.unreceiveVehicle(id).subscribe({
      next: () => {
        this.sweetAlert.success('Vehicle receipt unconfirmed');
        this.loadContracts();
      },
      error: (err) => this.sweetAlert.error('Error', err?.error?.message || 'Failed to unreceive vehicle')
    });
  }

  onCreateClick(): void {
    if (!this.context || !this.context.companyId || !this.context.branchId) {
      import('sweetalert2').then(Swal => {
        Swal.default.fire({
          icon: 'error',
          title: 'Error',
          text: 'You cannot add a car rental before selecting a company or branch.',
          confirmButtonColor: '#d33'
        });
      });
    } else {
      this.router.navigate(['/vehicle-rental/contracts/add']);
    }
  }
}
