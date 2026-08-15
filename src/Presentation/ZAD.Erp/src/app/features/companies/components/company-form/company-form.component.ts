import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CompanyService } from '../../services/company.service';
import { ContactsTableComponent } from '../../../../shared/components/contacts-table/contacts-table.component';
import { DocumentsTableComponent } from '../../../../shared/components/documents-table/documents-table.component';
import { SweetAlertService } from '../../../../core/services/sweet-alert.service';

@Component({
  selector: 'app-company-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink, ContactsTableComponent, DocumentsTableComponent],
  templateUrl: './company-form.component.html',
  styleUrl: './company-form.component.scss'
})
export class CompanyFormComponent implements OnInit {
  private fb = inject(FormBuilder);
  private companyService = inject(CompanyService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private sweetAlert = inject(SweetAlertService);

  companyForm!: FormGroup;
  isEditMode = false;
  companyId?: number;
  activeTab = 'companyData';
  logoPreview: string | null = null;
  selectedLogo: File | null = null;

  isSaving = false;
  saveError: string | null = null;
  saveSuccess = false;

  ngOnInit(): void {
    this.initForm();
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.isEditMode = true;
        this.companyId = +id;
        this.loadCompanyData(this.companyId);
      } else {
        this.isEditMode = false;
      }
    });
  }

  initForm(): void {
    this.companyForm = this.fb.group({
      code: [''],
      nameAr: ['', Validators.required],
      nameEn: [''],
      addressAr: [''],
      addressEn: [''],
      country: [''],
      city: [''],
      nationality: [''],
      language: [''],
      contacts: this.fb.array([]),
      documents: this.fb.array([])
    });
  }

  get contacts() { return this.companyForm.get('contacts') as FormArray; }
  get documents() { return this.companyForm.get('documents') as FormArray; }
  get nameArCtrl() { return this.companyForm.get('nameAr'); }

  companyCreatedAt?: string;
  companyUpdatedAt?: string;

  loadCompanyData(id: number) {
    this.companyService.getById(id).subscribe(company => {
      this.companyCreatedAt = company.createdAt;
      this.companyUpdatedAt = company.updatedAt;
      this.companyForm.patchValue(company);
      // Build logo preview URL
      if (company.logoPath) {
        this.logoPreview = company.logoPath.startsWith('http')
          ? company.logoPath
          : `https://zadapi.runasp.net/${company.logoPath}`;
      }

      company.contacts?.forEach(contact => {
        this.contacts.push(this.fb.group({
          id: [contact.id],
          type: [contact.type, Validators.required],
          value: [contact.value, Validators.required],
          name: [contact.name]
        }));
      });

      company.documents?.forEach(doc => {
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

  get companyEmail() {
    const contacts = this.contacts.value as any[];
    return contacts.find(c => c.type === 'Email')?.value || '-';
  }

  get companyPhone() {
    const contacts = this.contacts.value as any[];
    return contacts.find(c => c.type === 'Phone')?.value || '-';
  }

  save() {
    // Mark all fields as touched to trigger validation display
    this.companyForm.markAllAsTouched();

    if (this.companyForm.invalid) {
      this.saveError = 'Please fill in all required fields.';
      return;
    }

    this.isSaving = true;
    this.saveError = null;
    this.saveSuccess = false;

    const formData = new FormData();
    const formValue = this.companyForm.getRawValue();

    // Force Id append to be safe!
    if (this.isEditMode && this.companyId) {
       formData.append('Id', this.companyId.toString());
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

    // Append contacts array
    formValue.contacts.forEach((contact: any, index: number) => {
      formData.append(`Contacts[${index}].Type`, contact.type);
      formData.append(`Contacts[${index}].Value`, contact.value || '');
      formData.append(`Contacts[${index}].Name`, contact.name || '');
    });

    // Append documents array
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
      ? this.companyService.update(this.companyId!, formData)
      : this.companyService.create(formData);

    request$.subscribe({
      next: () => {
        this.isSaving = false;
        this.saveSuccess = true;
        this.sweetAlert.success('Success', 'Operation completed successfully!');
        setTimeout(() => this.router.navigate(['/settings/companies']), 1200);
      },
      error: (err) => {
        this.isSaving = false;
        console.error('Save error:', err);
        if (err?.error) {
          // Try to extract a human readable message
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
