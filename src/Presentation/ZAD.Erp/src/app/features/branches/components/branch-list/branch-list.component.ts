import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BranchService } from '../../services/branch.service';
import { BranchListDto } from '../../models/branch.model';

import { SweetAlertService } from '../../../../core/services/sweet-alert.service';

type SortField = 'code' | 'name' | 'address' | 'phone';
type SortDir = 'asc' | 'desc' | null;

import { PaginationComponent } from '../../../../shared/components/pagination/pagination.component';

@Component({
  selector: 'app-branch-list',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule, PaginationComponent],
  templateUrl: './branch-list.component.html',
  styleUrl: './branch-list.component.scss'
})
export class BranchListComponent implements OnInit {
  private branchService = inject(BranchService);
  private sweetAlert = inject(SweetAlertService);

  branches: BranchListDto[] = [];
  pageNumber = 1;
  pageSize = 10;
  totalCount = 0;

  searchTerm = '';
  sortField: SortField | null = null;
  sortDir: SortDir = null;

  ngOnInit(): void {
    this.loadBranches();
  }

  loadBranches(): void {
    const query = {
      pageNumber: this.pageNumber,
      pageSize: this.pageSize,
      searchTerm: this.searchTerm || undefined,
      sortColumn: this.sortField || undefined,
      sortDirection: this.sortDir || undefined
    };

    this.branchService.getPage(query).subscribe({
      next: (result) => {
        this.branches = result.items;
        this.totalCount = result.totalCount;
      },
      error: (err: any) => console.error(err)
    });
  }

  onSearch(): void {
    this.pageNumber = 1;
    this.loadBranches();
  }

  onPageChange(page: number): void {
    this.pageNumber = page;
    this.loadBranches();
  }

  onPageSizeChange(size: number): void {
    this.pageSize = size;
    this.pageNumber = 1;
    this.loadBranches();
  }

  toggleSort(field: SortField): void {
    if (this.sortField === field) {
      if (this.sortDir === 'asc') this.sortDir = 'desc';
      else if (this.sortDir === 'desc') { this.sortDir = null; this.sortField = null; }
    } else {
      this.sortField = field;
      this.sortDir = 'asc';
    }
    this.loadBranches();
  }

  getSortIcon(field: SortField): string {
    if (this.sortField !== field) return 'fas fa-sort text-muted';
    if (this.sortDir === 'asc') return 'fas fa-sort-amount-up text-teal';
    return 'fas fa-sort-amount-down-alt text-teal';
  }

  async deleteBranch(id: number) {
    const confirmed = await this.sweetAlert.confirm(
      'Confirm',
      'Are you sure you want to delete item(s)?'
    );
    if (confirmed) {
      this.branchService.delete(id).subscribe({
        next: () => {
          this.sweetAlert.success('Branch deleted successfully');
          this.loadBranches();
        },
        error: (err: any) => {
          console.error('Error deleting branch', err);
          this.sweetAlert.error('Error', 'Failed to delete branch');
        }
      });
    }
  }

  getLogoUrl(logoPath: string | null): string {
    if (!logoPath) return 'assets/placeholder.png';
    if (logoPath.startsWith('http')) return logoPath;
    return `https://zadapi.runasp.net/${logoPath}`;
  }

  onImgError(event: any): void {
    event.target.src = 'assets/placeholder.png';
  }

  async toggleActive(branch: BranchListDto, event: Event) {
    event.preventDefault();
    
    const action = branch.isActive ? 'deactivate' : 'activate';
    const confirmed = await this.sweetAlert.confirm(
      `Confirm ${action}`,
      `Are you sure you want to ${action} this branch?`
    );
    
    if (confirmed) {
      this.branchService.toggleActive(branch.id).subscribe({
        next: () => {
          this.sweetAlert.success(`Branch ${action}d successfully`);
          this.loadBranches();
        },
        error: (err: any) => {
          console.error(err);
          this.sweetAlert.error('Error', `Failed to ${action} branch`);
          this.loadBranches();
        }
      });
    } else {
      const checkbox = event.target as HTMLInputElement;
      checkbox.checked = branch.isActive;
    }
  }
}
