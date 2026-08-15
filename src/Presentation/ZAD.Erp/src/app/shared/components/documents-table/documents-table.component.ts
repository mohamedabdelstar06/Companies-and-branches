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
  template: `
    <div [formGroup]="parentForm">
      <div formArrayName="documents">
        <div class="row mb-2" *ngFor="let doc of documents.controls; let i=index" [formGroupName]="i">
          <div class="col-md-3">
            <label *ngIf="i===0" class="form-label text-muted fw-bold small">Document Type</label>
            <select class="form-select" formControlName="type"
              [class.is-invalid]="doc.get('type')?.invalid && doc.get('type')?.touched">
              <option value="" disabled>Select type</option>
              <option *ngFor="let dt of documentTypes" [ngValue]="dt.value">{{ dt.label }}</option>
            </select>
            <div class="invalid-feedback">Document type is required.</div>
          </div>
          <div class="col-md-3">
            <label *ngIf="i===0" class="form-label text-muted fw-bold small">Document Number</label>
            <input type="text" class="form-control" formControlName="documentNumber"
              [class.is-invalid]="doc.get('documentNumber')?.invalid && doc.get('documentNumber')?.touched"
              placeholder="e.g. A123456">
            <div class="invalid-feedback">Document number is required.</div>
          </div>
          <div class="col-md-3">
            <label *ngIf="i===0" class="form-label text-muted fw-bold small">Attach File</label>
            <div class="input-group">
              <input type="text" class="form-control bg-white" [value]="getFileName(i)" readonly placeholder="Choose file" (click)="fileInput.click()" style="cursor: pointer;">
              <input type="file" class="d-none" #fileInput (change)="onDocumentFileChange($event, i)">
              <a *ngIf="isExistingFile(i)" class="btn btn-outline-teal" [href]="getFileUrl(i)" target="_blank" title="Download">
                <i class="fas fa-download"></i>
              </a>
              <button class="btn btn-outline-teal" type="button" (click)="fileInput.click()" title="Upload File">
                <i class="fas fa-upload"></i>
              </button>
            </div>
          </div>
          <div class="col-md-2">
            <label *ngIf="i===0" class="form-label text-muted fw-bold small">Expiry Date</label>
            <input type="date" class="form-control" formControlName="expiryDate">
          </div>
          <div class="col-md-1 d-flex align-items-end justify-content-end">
            <button class="btn btn-icon text-danger" type="button" (click)="removeDocument(i)">
              <i class="fas fa-trash"></i>
            </button>
          </div>
        </div>
      </div>
      <button class="btn btn-outline-teal btn-sm mt-2" type="button" (click)="addDocument()">
        <i class="fas fa-plus"></i> Add Document
      </button>
    </div>
  `
})
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
