import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { BranchService } from '../../services/branch.service';
import { CompanyService } from '../../../companies/services/company.service';
import { CompanyListDto } from '../../../companies/models/company.model';
import { ContactsTableComponent } from '../../../../shared/components/contacts-table/contacts-table.component';
import { DocumentsTableComponent } from '../../../../shared/components/documents-table/documents-table.component';
import { SweetAlertService } from '../../../../core/services/sweet-alert.service';

@Component({
  selector: 'app-branch-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink, ContactsTableComponent, DocumentsTableComponent],
  templateUrl: './branch-form.component.html',
  styleUrl: './branch-form.component.scss'
})
export class BranchFormComponent implements OnInit {
  private fb = inject(FormBuilder);
  private branchService = inject(BranchService);
  private companyService = inject(CompanyService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private sweetAlert = inject(SweetAlertService);

  branchForm!: FormGroup;
  isEditMode = false;
  branchId?: number;
  activeTab = 'branchData';
  logoPreview: string | null = null;
  selectedLogo: File | null = null;

  companies: CompanyListDto[] = [];

  isSaving = false;
  saveError: string | null = null;
  saveSuccess = false;

  ngOnInit(): void {
    this.initForm();
    this.loadCompanies();
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.isEditMode = true;
        this.branchId = +id;
        this.loadBranchData(this.branchId);
      } else {
        this.isEditMode = false;
      }
    });
  }

  loadCompanies() {
    this.companyService.getPage({ pageNumber: 1, pageSize: 1000 }).subscribe(res => {
      this.companies = res.items;
    });
  }

  initForm(): void {
    this.branchForm = this.fb.group({
      code: [''],
      nameAr: ['', Validators.required],
      nameEn: [''],
      companyId: ['', Validators.required],
      addressAr: [''],
      addressEn: [''],
      country: [''],
      city: [''],
      costCenter: [''],
      isMainBranch: [false],
      contacts: this.fb.array([]),
      documents: this.fb.array([])
    });
  }

  get contacts() { return this.branchForm.get('contacts') as FormArray; }
  get documents() { return this.branchForm.get('documents') as FormArray; }
  get nameArCtrl() { return this.branchForm.get('nameAr'); }
  get companyIdCtrl() { return this.branchForm.get('companyId'); }

  branchCreatedAt?: string;
  branchUpdatedAt?: string;

  loadBranchData(id: number) {
    this.branchService.getById(id).subscribe(branch => {
      this.branchCreatedAt = branch.createdAt;
      this.branchUpdatedAt = branch.updatedAt;
      this.branchForm.patchValue(branch);
      if (branch.logoPath) {
        this.logoPreview = branch.logoPath.startsWith('http')
          ? branch.logoPath
          : `https://zadapi.runasp.net/${branch.logoPath}`;
      }

      branch.contacts?.forEach(contact => {
        this.contacts.push(this.fb.group({
          id: [contact.id],
          type: [contact.type, Validators.required],
          value: [contact.value, Validators.required],
          name: [contact.name]
        }));
      });

      branch.documents?.forEach(doc => {
        this.documents.push(this.fb.group({
          id: [doc.id],
          type: [doc.type, Validators.required],
          documentNumber: [doc.documentNumber, Validators.required],
          attachFile: [doc.filePath],
          expiryDate: [doc.expiryDate]
        }));
      });
    });
  }

  onLogoChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedLogo = file;
      const reader = new FileReader();
      reader.onload = () => this.logoPreview = reader.result as string;
      reader.readAsDataURL(file);
    }
  }

  get branchEmail() {
    const contacts = this.contacts.value as any[];
    return contacts.find(c => c.type === 'Email')?.value || '-';
  }

  get branchPhone() {
    const contacts = this.contacts.value as any[];
    return contacts.find(c => c.type === 'Phone')?.value || '-';
  }

  save() {
    this.branchForm.markAllAsTouched();

    if (this.branchForm.invalid) {
      this.saveError = 'Please fill in all required fields (Arabic Name and Company are required).';
      return;
    }

    this.isSaving = true;
    this.saveError = null;
    this.saveSuccess = false;

    const formData = new FormData();
    const formValue = this.branchForm.getRawValue();

    // Force Id append to be safe!
    if (this.isEditMode && this.branchId) {
       formData.append('Id', this.branchId.toString());
    }

    // Append basic info
    Object.keys(formValue).forEach(key => {
      if (key !== 'contacts' && key !== 'documents' && key !== 'id' && formValue[key] !== null && formValue[key] !== undefined) {
        formData.append(key, formValue[key]);
      }
    });

    if (this.selectedLogo) {
      formData.append('Logo', this.selectedLogo);
    }

    formValue.contacts.forEach((contact: any, index: number) => {
      formData.append(`Contacts[${index}].Type`, contact.type);
      formData.append(`Contacts[${index}].Value`, contact.value || '');
      formData.append(`Contacts[${index}].Name`, contact.name || '');
    });

    formValue.documents.forEach((doc: any, index: number) => {
      formData.append(`Documents[${index}].Type`, doc.type);
      formData.append(`Documents[${index}].DocumentNumber`, doc.documentNumber || '');
      if (doc.expiryDate) {
        formData.append(`Documents[${index}].ExpiryDate`, doc.expiryDate);
      }
      if (doc.attachFile instanceof File) {
        formData.append(`Documents[${index}].AttachFile`, doc.attachFile);
      }
    });

    const request$ = this.isEditMode
      ? this.branchService.update(this.branchId!, formData)
      : this.branchService.create(formData);

    request$.subscribe({
      next: () => {
        this.isSaving = false;
        this.saveSuccess = true;
        this.sweetAlert.success('Success', 'Operation completed successfully!');
        setTimeout(() => this.router.navigate(['/settings/branches']), 1200);
      },
      error: (err) => {
        this.isSaving = false;
        console.error('Save error:', err);
        if (err?.error) {
          if (typeof err.error === 'string') {
            this.saveError = err.error;
          } else if (err.error?.title) {
            this.saveError = err.error.title;
            if (err.error?.errors) {
              const msgs = Object.values(err.error.errors).flat();
              this.saveError += ': ' + msgs.join(', ');
            }
          } else if (err.error?.message) {
            this.saveError = err.error.message;
          } else {
            this.saveError = `Error ${err.status}: ${err.statusText}`;
          }
        } else {
          this.saveError = `Error ${err.status}: ${err.statusText || 'Unknown error'}`;
        }
      }
    });
  }
}
