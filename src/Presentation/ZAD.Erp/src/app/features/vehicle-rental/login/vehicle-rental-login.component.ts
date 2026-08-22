import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { VehicleRentalContextService } from '../shared/services/vehicle-rental-context.service';
import { CompanyService } from '../../companies/services/company.service';
import { BranchService } from '../../branches/services/branch.service';
import { CompanyListDto } from '../../companies/models/company.model';
import { BranchListDto } from '../../branches/models/branch.model';

@Component({
  selector: 'app-vehicle-rental-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './vehicle-rental-login.component.html',
  styleUrl: './vehicle-rental-login.component.scss',
  styles: [`
    .login-bg { background: linear-gradient(135deg, #e3f2fd 0%, #bbdefb 100%); }
    .btn-teal { background-color: #176B6B; border-color: #176B6B; color: white; }
    .btn-teal:hover { background-color: #135858; color: white; }
  `]
})
export class VehicleRentalLoginComponent implements OnInit {
  companies: CompanyListDto[] = [];
  allBranches: BranchListDto[] = [];
  filteredBranches: BranchListDto[] = [];
  
  selectedCompanyId: number | null = null;
  selectedBranchId: number | null = null;

  private contextService = inject(VehicleRentalContextService);
  private companyService = inject(CompanyService);
  private branchService = inject(BranchService);
  private router = inject(Router);

  ngOnInit() {
    this.companyService.getPage({ pageNumber: 1, pageSize: 100 }).subscribe(res => {
      this.companies = res.items;
    });
    
    this.branchService.getPage({ pageNumber: 1, pageSize: 100 }).subscribe(res => {
      this.allBranches = res.items;
    });
  }

  onCompanyChange() {
    this.selectedBranchId = null;
    if (this.selectedCompanyId) {
      const company = this.companies.find(c => c.id == this.selectedCompanyId);
      if (company) {
        this.filteredBranches = this.allBranches.filter(b => b.companyName === company.name);
      } else {
        this.filteredBranches = [];
      }
    } else {
      this.filteredBranches = [];
    }
  }

  enterModule() {
    if (this.selectedCompanyId && this.selectedBranchId) {
      const company = this.companies.find(c => c.id == this.selectedCompanyId);
      const branch = this.allBranches.find(b => b.id == this.selectedBranchId);
      
      this.contextService.setContext({
        companyId: this.selectedCompanyId,
        branchId: this.selectedBranchId,
        companyName: company?.name || null,
        branchName: branch?.name || null,
        companyLogo: company?.logo || null
      });
      this.router.navigate(['/dashboard']);
    } else {
      import('sweetalert2').then(Swal => {
        Swal.default.fire({
          icon: 'warning',
          title: 'Selection Required',
          text: 'You must select a company and a branch before continuing.',
          confirmButtonColor: '#176B6B'
        });
      });
    }
  }

  onSkip() {
    this.contextService.clearContext();
    this.router.navigate(['/vehicle-rental/contracts']);
  }
}
