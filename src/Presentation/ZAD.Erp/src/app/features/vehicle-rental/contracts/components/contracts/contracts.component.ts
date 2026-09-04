import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ContractService } from '../../services/contract.service';
import { SweetAlertService } from '@app/core/services/sweet-alert.service';
import { VehicleRentalContextService, VehicleRentalContext } from '../../../shared/services/vehicle-rental-context.service';
import { DatePipe, DecimalPipe, NgClass } from '@angular/common';
import { PaginationComponent } from '../../../../../shared/components/pagination/pagination.component';

type SortField = 'id' | 'plateNo' | 'brand' | 'date' | 'toDate' | 'periodInDays' | 'actualPeriodInDays' | 'contractType' | 'tenantName' | 'remainingAmount' | 'deliveryStatus' | 'status';
type SortDir = 'asc' | 'desc' | null;

@Component({
  selector: 'app-contracts',
  standalone: true,
  imports: [RouterLink, FormsModule, DatePipe, DecimalPipe, NgClass, PaginationComponent],
  templateUrl: './contracts.component.html',
  styleUrl: './contracts.component.scss'
})
export class ContractsComponent implements OnInit {
  private contractService = inject(ContractService);
  private sweetAlert = inject(SweetAlertService);
  private contextService = inject(VehicleRentalContextService);
  private router = inject(Router);

  context: VehicleRentalContext | null = null;

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
    const query = {
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
      searchTerm: this.searchTerm || undefined,
      sortColumn: this.sortField || undefined,
      sortDirection: this.sortDir || undefined
    };

    this.contractService.getPage(query).subscribe({
      next: (result) => {
        this.contracts = result.items;
        this.totalCount = result.totalCount;
      },
      error: (err: any) => console.error(err)
    });
  }

  onSearch(): void {
    this.pageNumber = 1;
    this.loadContracts();
  }

  onPageSizeChange(size: number): void {
    this.pageSize = size;
    this.pageNumber = 1;
    this.loadContracts();
  }

  changePage(page: number): void {
    const totalPages = Math.ceil(this.totalCount / this.pageSize) || 1;
    if (page >= 1 && page <= totalPages) {
      this.pageNumber = page;
      this.loadContracts();
    }
  }

  getPages(): number[] {
    const totalPages = Math.ceil(this.totalCount / this.pageSize) || 1;
    const pages: number[] = [];
    for (let i = 1; i <= totalPages; i++) {
      pages.push(i);
    }
    return pages;
  }

  min(a: number, b: number): number {
    return Math.min(a, b);
  }

  toggleSort(field: SortField): void {
    if (this.sortField === field) {
      if (this.sortDir === 'asc') this.sortDir = 'desc';
      else if (this.sortDir === 'desc') { this.sortDir = null; this.sortField = null; }
    } else {
      this.sortField = field;
      this.sortDir = 'asc';
    }
    this.loadContracts();
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
