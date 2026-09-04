import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CompanyService } from '../../services/company.service';
import { CompanyListDto } from '../../models/company.model';

import { SweetAlertService } from '../../../../core/services/sweet-alert.service';

type SortField = 'code' | 'name' | 'address' | 'phone';
type SortDir = 'asc' | 'desc' | null;

import { PaginationComponent } from '../../../../shared/components/pagination/pagination.component';

@Component({
  selector: 'app-company-list',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule, PaginationComponent],
  templateUrl: './company-list.component.html',
  styleUrl: './company-list.component.scss'
})
export class CompanyListComponent implements OnInit {
  private companyService = inject(CompanyService);
  private sweetAlert = inject(SweetAlertService);

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
    const query = {
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
      searchTerm: this.searchTerm || undefined,
      sortColumn: this.sortField || undefined,
      sortDirection: this.sortDir || undefined
    };

    this.companyService.getPage(query).subscribe({
      next: (result) => {
        this.companies = result.items;
        this.totalCount = result.totalCount;
      },
      error: (err: any) => console.error(err)
    });
  }

  onSearch(): void {
    this.pageNumber = 1;
    this.loadCompanies();
  }

  onPageChange(page: number): void {
    this.pageNumber = page;
    this.loadCompanies();
  }

  onPageSizeChange(size: number): void {
    this.pageSize = size;
    this.pageNumber = 1;
    this.loadCompanies();
  }

  toggleSort(field: SortField): void {
    if (this.sortField === field) {
      if (this.sortDir === 'asc') this.sortDir = 'desc';
      else if (this.sortDir === 'desc') { this.sortDir = null; this.sortField = null; }
    } else {
      this.sortField = field;
      this.sortDir = 'asc';
    }
    this.loadCompanies();
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
