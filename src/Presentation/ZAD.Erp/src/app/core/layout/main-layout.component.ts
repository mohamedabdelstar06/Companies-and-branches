import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { VehicleRentalContextService, VehicleRentalContext } from '../../features/vehicle-rental/shared/services/vehicle-rental-context.service';
import { CompanyService } from '../../features/companies/services/company.service';
import { BranchService } from '../../features/branches/services/branch.service';
import { CompanyListDto } from '../../features/companies/models/company.model';
import { BranchListDto } from '../../features/branches/models/branch.model';
import { SweetAlertService } from '../services/sweet-alert.service';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink, FormsModule],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss',})
export class MainLayoutComponent implements OnInit {
  context: VehicleRentalContext | null = null;
  companies: CompanyListDto[] = [];
  allBranches: BranchListDto[] = [];
  filteredBranches: BranchListDto[] = [];

  private contextService = inject(VehicleRentalContextService);
  private companyService = inject(CompanyService);
  private branchService = inject(BranchService);
  private sweetAlert = inject(SweetAlertService);

  ngOnInit() {
    this.contextService.context$.subscribe(ctx => {
      this.context = ctx;
      this.updateFilteredBranches();
    });

    this.companyService.getPage({ pageNumber: 1, pageSize: 100 }).subscribe(res => {
      this.companies = res.items;
    });

    this.branchService.getPage({ pageNumber: 1, pageSize: 100 }).subscribe(res => {
      this.allBranches = res.items;
      this.updateFilteredBranches();
    });
  }

  updateFilteredBranches() {
    if (this.context?.companyName) {
      this.filteredBranches = this.allBranches.filter(b => b.companyName === this.context?.companyName);
    } else {
      this.filteredBranches = [];
    }
  }

  async onCompanyChange(newCompanyId: number | null) {
    if (newCompanyId === this.context?.companyId) return;

    const confirmed = await this.sweetAlert.confirm(
      'Confirm',
      'If you changed the company, page will be refreshed and you may lose any unsaved data. Are sure you want to continue ?'
    );

    if (confirmed) {
      if (newCompanyId) {
        const company = this.companies.find(c => c.id == newCompanyId);
        this.contextService.setContext({
          companyId: newCompanyId,
          branchId: null,
          companyName: company?.name || null,
          branchName: null,
          companyLogo: company?.logo || null
        });
      } else {
        this.contextService.clearContext();
      }
      window.location.reload();
    }
  }

  async onBranchChange(newBranchId: number | null) {
    if (newBranchId === this.context?.branchId) return;

    const confirmed = await this.sweetAlert.confirm(
      'Confirm',
      'If you changed the branch, page will be refreshed and you may lose any unsaved data. Are sure you want to continue ?'
    );

    if (confirmed) {
      if (newBranchId && this.context?.companyId) {
        const branch = this.allBranches.find(b => b.id == newBranchId);
        this.contextService.setContext({
          ...this.context,
          branchId: newBranchId,
          branchName: branch?.name || null
        });
      } else if (!newBranchId && this.context) {
        this.contextService.setContext({
          ...this.context,
          branchId: null,
          branchName: null
        });
      }
      window.location.reload();
    }
  }

  getLogoUrl(logoPath: string | null | undefined): string {
    if (!logoPath) return 'assets/placeholder.png';
    if (logoPath.startsWith('http')) return logoPath;
    return `https://zadapi.runasp.net${logoPath.startsWith('/') ? '' : '/'}${logoPath}`;
  }

  onImgError(event: any): void {
    // Hide the image container completely if the image fails to load
    if (event?.target?.parentElement) {
      event.target.parentElement.style.display = 'none';
    }
  }
}
