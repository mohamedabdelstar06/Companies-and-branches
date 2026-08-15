import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BranchService } from '../../services/branch.service';
import { BranchListDto } from '../../models/branch.model';

import { SweetAlertService } from '../../../../core/services/sweet-alert.service';

type SortField = 'code' | 'name' | 'address' | 'phone';
type SortDir = 'asc' | 'desc' | null;

@Component({
  selector: 'app-branch-list',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './branch-list.component.html',
  styleUrl: './branch-list.component.scss'
})
export class BranchListComponent implements OnInit {
  private branchService = inject(BranchService);
  private sweetAlert = inject(SweetAlertService);

  allBranches: BranchListDto[] = [];
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
    this.branchService.getPage({ pageNumber: 1, pageSize: 9999 }).subscribe({
      next: (result) => {
        this.allBranches = result.items;
        this.totalCount = result.totalCount;
        this.applyFilter();
      },
      error: (err: any) => console.error(err)
    });
  }

  applyFilter(): void {
    const term = this.searchTerm.toLowerCase().trim();
    let filtered = this.allBranches;

    if (term) {
      filtered = filtered.filter(b =>
        (b.code?.toLowerCase() || '').includes(term) ||
        (b.name?.toLowerCase() || '').includes(term) ||
        (b.address?.toLowerCase() || '').includes(term) ||
        (b.phone?.toLowerCase() || '').includes(term)
      );
    }

    if (this.sortField && this.sortDir) {
      const field = this.sortField;
      const dir = this.sortDir === 'asc' ? 1 : -1;
      filtered = [...filtered].sort((a, b) => {
        const av = ((a as any)[field] || '').toLowerCase();
        const bv = ((b as any)[field] || '').toLowerCase();
        return av < bv ? -dir : av > bv ? dir : 0;
      });
    }

    this.branches = filtered;
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
