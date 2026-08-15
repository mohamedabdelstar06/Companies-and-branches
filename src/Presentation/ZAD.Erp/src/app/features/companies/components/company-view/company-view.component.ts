import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CompanyService } from '../../services/company.service';
import { CompanyDetailDto } from '../../models/company.model';
import { FileDownloadService } from '../../../../core/services/file-download.service';

@Component({
  selector: 'app-company-view',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './company-view.component.html',
  styleUrl: './company-view.component.scss'
})
export class CompanyViewComponent implements OnInit {
  company?: CompanyDetailDto;
  activeTab = 'companyData';

  constructor(
    private route: ActivatedRoute,
    private companyService: CompanyService,
    private fileDownloadService: FileDownloadService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadCompany(+id);
    }
  }

  loadCompany(id: number) {
    this.companyService.getById(id).subscribe({
      next: (data) => this.company = data,
      error: (err) => console.error('Failed to load company', err)
    });
  }

  getLogoUrl(logoPath: string | null): string {
    if (!logoPath) return 'assets/placeholder.png';
    if (logoPath.startsWith('http')) return logoPath;
    return `https://zadapi.runasp.net${logoPath.startsWith('/') ? '' : '/'}${logoPath}`;
  }

  getFileName(doc: any): string {
    if (!doc || !doc.filePath) return '';
    // Create clean file name based on document type/number if possible
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

  get companyPhone() {
    return this.company?.contacts?.find(c => c.type === 'Phone')?.value || '-';
  }

  get companyEmail() {
    return this.company?.contacts?.find(c => c.type === 'Email')?.value || '-';
  }
}
