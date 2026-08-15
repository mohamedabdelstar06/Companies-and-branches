import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CompanyService } from '../../services/company.service';
import { CompanyListDto } from '../../models/company.model';

import { SweetAlertService } from '../../../../core/services/sweet-alert.service';

type SortField = 'code' | 'name' | 'address' | 'phone';
type SortDir = 'asc' | 'desc' | null;

@Component({
  selector: 'app-company-list',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './company-list.component.html',
  styleUrl: './company-list.component.scss'
})
export class CompanyListComponent implements OnInit {
  private companyService = inject(CompanyService);
  private sweetAlert = inject(SweetAlertService);

  allCompanies: CompanyListDto[] = [];
  companies: CompanyListDto[] = [];
  pageNumber = 1;
  pageSize = 10;
  totalCount = 0;

  searchTerm = '';
  sortField: SortField | null = null;
  sortDir: SortDir = null;

  ngOnInit(): void {
    this.loadCompanies();
  }

  loadCompanies(): void {
    this.companyService.getPage({ pageNumber: 1, pageSize: 9999 }).subscribe({
      next: (result) => {
        this.allCompanies = result.items;
        this.totalCount = result.totalCount;
        this.applyFilter();
      },
      error: (err: any) => console.error(err)
    });
  }

  applyFilter(): void {
    const term = this.searchTerm.toLowerCase().trim();
    let filtered = this.allCompanies;

    if (term) {
      filtered = filtered.filter(c =>
        (c.code?.toLowerCase() || '').includes(term) ||
        (c.name?.toLowerCase() || '').includes(term) ||
        (c.address?.toLowerCase() || '').includes(term) ||
        (c.phone?.toLowerCase() || '').includes(term)
      );
    }

    if (this.sortField && this.sortDir) {
      const field = this.sortField;
      const dir = this.sortDir === 'asc' ? 1 : -1;
      filtered = [...filtered].sort((a, b) => {
        const av = (a[field] || '').toLowerCase();
        const bv = (b[field] || '').toLowerCase();
        return av < bv ? -dir : av > bv ? dir : 0;
      });
    }

    this.companies = filtered;
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

  async deleteCompany(id: number) {
    const confirmed = await this.sweetAlert.confirm(
      'Confirm',
      'Are you sure you want to delete item(s)?'
    );
    if (confirmed) {
      this.companyService.delete(id).subscribe({
        next: () => {
          this.sweetAlert.success('Company deleted successfully');
          this.loadCompanies();
        },
        error: (err: any) => {
          console.error('Error deleting company', err);
          this.sweetAlert.error('Error', 'Failed to delete company');
        }
      });
    }
  }

  getLogoUrl(logoPath: string | null): string {
    if (!logoPath) return 'assets/placeholder.png';
    if (logoPath.startsWith('http')) return logoPath;
    return `https://zadapi.runasp.net${logoPath.startsWith('/') ? '' : '/'}${logoPath}`;
  }

  onImgError(event: any): void {
    event.target.src = 'assets/placeholder.png';
  }

  async toggleActive(company: CompanyListDto, event: Event) {
    // Prevent the default toggle visually until confirmed
    event.preventDefault();
    
    const action = company.isActive ? 'deactivate' : 'activate';
    const confirmed = await this.sweetAlert.confirm(
      `Confirm ${action}`,
      `Are you sure you want to ${action} this company?`
    );
    
    if (confirmed) {
      // Proceed with the toggle
      this.companyService.toggleActive(company.id).subscribe({
        next: () => {
          this.sweetAlert.success(`Company ${action}d successfully`);
          this.loadCompanies();
        },
        error: (err: any) => {
          console.error(err);
          this.sweetAlert.error('Error', `Failed to ${action} company`);
          this.loadCompanies();
        }
      });
    } else {
      // Revert the visual toggle state
      const checkbox = event.target as HTMLInputElement;
      checkbox.checked = company.isActive;
    }
  }
}
