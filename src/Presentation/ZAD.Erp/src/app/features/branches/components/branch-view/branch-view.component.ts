import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { BranchService } from '../../services/branch.service';
import { BranchDetailDto } from '../../models/branch.model';
import { FileDownloadService } from '../../../../core/services/file-download.service';

@Component({
  selector: 'app-branch-view',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './branch-view.component.html',
  styleUrl: './branch-view.component.scss'
})
export class BranchViewComponent implements OnInit {
  branch?: BranchDetailDto;
  activeTab = 'companyData';

  constructor(
    private route: ActivatedRoute,
    private branchService: BranchService,
    private fileDownloadService: FileDownloadService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadBranch(+id);
    }
  }

  loadBranch(id: number) {
    this.branchService.getById(id).subscribe({
      next: (data) => this.branch = data,
      error: (err) => console.error('Failed to load branch', err)
    });
  }

  getLogoUrl(logoPath: string | null): string {
    if (!logoPath) return 'assets/placeholder.png';
    if (logoPath.startsWith('http')) return logoPath;
    return `https://zadapi.runasp.net${logoPath.startsWith('/') ? '' : '/'}${logoPath}`;
  }

  getFileName(doc: any): string {
    if (!doc || !doc.filePath) return '';
    if (doc.type && doc.documentNumber) {
      const urlParts = doc.filePath.split('.');
      const ext = urlParts.length > 1 ? urlParts[urlParts.length - 1] : 'pdf';
      return `${doc.type}-${doc.documentNumber}.${ext}`;
    }
    const parts = doc.filePath.split('/');
    return parts[parts.length - 1];
  }

  downloadDocument(doc: any) {
    if (!doc || !doc.filePath) return;
    const url = doc.filePath.startsWith('http') ? doc.filePath : `https://zadapi.runasp.net${doc.filePath.startsWith('/') ? '' : '/'}${doc.filePath}`;
    
    let fileName = this.getFileName(doc);
    
    this.fileDownloadService.downloadFile(url, fileName);
  }

  get branchPhone(): string {
    return this.branch?.contacts?.find(c => c.type === 'Phone')?.value || '-';
  }

  get branchEmail(): string {
    return this.branch?.contacts?.find(c => c.type === 'Email')?.value || '-';
  }
}
