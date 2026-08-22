import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ContractService } from '../../services/contract.service';
import { SweetAlertService } from '@app/core/services/sweet-alert.service';
import { VehicleRentalContextService, VehicleRentalContext } from '../../../shared/services/vehicle-rental-context.service';

type SortField = 'accountingNo' | 'plateNo' | 'brand' | 'date' | 'toDate' | 'companyName' | 'branchName' | 'tenantName' | 'status' | 'createdAt';
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

  ngOnInit(): void {
    this.contextService.context$.subscribe(ctx => {
      this.context = ctx;
    });
    this.loadContracts();
  }

  changeContext() {
    this.contextService.clearContext();
    this.router.navigate(['/vehicle-rental/login']);
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
        (c.accountingNo?.toLowerCase() || '').includes(term) ||
        (c.plateNo?.toLowerCase() || '').includes(term) ||
        (c.companyName?.toLowerCase() || '').includes(term) ||
        (c.branchName?.toLowerCase() || '').includes(term) ||
        (c.tenantName?.toLowerCase() || '').includes(term)
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

  async deleteContract(id: number) {
    const confirmed = await this.sweetAlert.confirm(
      'Confirm',
      'Are you sure you want to delete item(s)?'
    );
    if (confirmed) {
      this.contractService.delete(id).subscribe({
        next: () => {
          this.sweetAlert.success('Contract deleted successfully');
          this.loadContracts();
        },
        error: (err: any) => {
          console.error('Error deleting contract', err);
          this.sweetAlert.error('Error', 'Failed to delete contract');
        }
      });
    }
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
