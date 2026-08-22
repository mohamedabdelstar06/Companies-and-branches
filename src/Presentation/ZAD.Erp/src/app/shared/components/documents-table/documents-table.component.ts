import { Component, Input, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { FileDownloadService } from '../../../core/services/file-download.service';
import { SweetAlertService } from '../../../core/services/sweet-alert.service';

export const DOCUMENT_TYPES = [
  { value: 'Passport',                label: 'Passport' },
  { value: 'NationalID',              label: 'National ID' },
  { value: 'DrivingLicense',          label: 'Driving License' },
  { value: 'SocialInsuranceCard',     label: 'Social Insurance Card' },
  { value: 'BirthCertificate',        label: 'Birth Certificate' },
  { value: 'CompanyRegistration',     label: 'Company Registration' },
  { value: 'TaxIdentificationNumber', label: 'Tax Identification Number' },
  { value: 'BusinessLicense',         label: 'Business License' },
  { value: 'ArticlesOfIncorporation', label: 'Articles of Incorporation' },
  { value: 'EmploymentVerification',  label: 'Employment Verification' },
  { value: 'LeaseAgreement',          label: 'Lease Agreement' },
  { value: 'ShareholderAgreement',    label: 'Shareholder Agreement' },
  { value: 'VehicleLicense',          label: 'Vehicle License' },
  { value: 'Residence',               label: 'Residence' },
  { value: 'MaintenanceDocument',     label: 'Maintenance Document' },
];

@Component({
  selector: 'app-documents-table',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './documents-table.component.html',
  styleUrl: './documents-table.component.scss',})
export class DocumentsTableComponent implements OnInit {
  @Input() parentForm!: FormGroup;
  
  sweetAlert = inject(SweetAlertService);

  constructor(private fb: FormBuilder, private fileDownloadService: FileDownloadService) {}

  ngOnInit(): void {}

  documentTypes = DOCUMENT_TYPES;

  get documents() {
    return this.parentForm.get('documents') as FormArray;
  }

  addDocument() {
    this.documents.push(this.fb.group({
      id: [null],
      type: ['', Validators.required],
      documentNumber: ['', Validators.required],
      attachFile: [null],
      expiryDate: ['']
    }));
  }

  async removeDocument(index: number) {
    const confirmed = await this.sweetAlert.confirm(
      'Confirm',
      'Are you sure you want to delete item(s)?'
    );
    if (confirmed) {
      this.documents.removeAt(index);
      this.sweetAlert.success('Success', 'Document removed successfully');
    }
  }

  onDocumentFileChange(event: any, index: number) {
    const file = event.target.files[0];
    if (file) {
      this.documents.at(index).patchValue({ attachFile: file });
    }
  }

  isExistingFile(index: number): boolean {
    const file = this.documents.at(index).get('attachFile')?.value;
    return file && typeof file === 'string';
  }

  getFileUrl(index: number): string {
    const file = this.documents.at(index).get('attachFile')?.value;
    if (typeof file === 'string') {
      return file.startsWith('http') ? file : `https://zadapi.runasp.net${file.startsWith('/') ? '' : '/'}${file}`;
    }
    return '';
  }

  getFileName(index: number): string {
    const file = this.documents.at(index).get('attachFile')?.value;
    if (file instanceof File) return file.name;
    if (typeof file === 'string') {
      const type = this.documents.at(index).get('type')?.value;
      const docNum = this.documents.at(index).get('documentNumber')?.value;
      if (type && docNum) {
        return `${type}-${docNum}`;
      }
      const parts = file.split('/');
      return parts[parts.length - 1];
    }
    return '';
  }

  downloadFile(index: number) {
    const url = this.getFileUrl(index);
    if (url) {
      let fileName = this.getFileName(index);
      if (!fileName.includes('.')) {
         const parts = url.split('/');
         const realName = parts[parts.length - 1];
         const extIndex = realName.lastIndexOf('.');
         if (extIndex !== -1) {
             fileName += realName.substring(extIndex);
         } else {
             fileName += '.pdf';
         }
      }
      this.fileDownloadService.downloadFile(url, fileName);
    }
  }
}
