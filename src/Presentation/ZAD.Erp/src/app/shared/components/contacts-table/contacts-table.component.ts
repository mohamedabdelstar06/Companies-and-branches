import { Component, Input, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SweetAlertService } from '../../../core/services/sweet-alert.service';

export const CONTACT_TYPES = [
  { value: 'Phone',       label: 'Phone',       placeholder: '+20 123 456 7890', icon: 'fa-phone' },
  { value: 'PostalMail',  label: 'Postal Mail', placeholder: '123 Main St, Cairo 12345', icon: 'fa-envelope' },
  { value: 'LiveChat',    label: 'Live Chat',   placeholder: 'Chat handle or URL', icon: 'fa-comments' },
  { value: 'Website',     label: 'Website',     placeholder: 'https://example.com', icon: 'fa-globe' },
  { value: 'VideoCall',   label: 'Video Call',  placeholder: 'Zoom/Meet link or ID', icon: 'fa-video' },
  { value: 'Fax',         label: 'Fax',         placeholder: '+20 2 1234 5678', icon: 'fa-fax' },
  { value: 'Instagram',   label: 'Instagram',   placeholder: '@username', icon: 'fa-instagram' },
  { value: 'Whatsapp',    label: 'Whatsapp',    placeholder: '+20 123 456 7890', icon: 'fa-whatsapp' },
  { value: 'SMS',         label: 'SMS',         placeholder: '+20 123 456 7890', icon: 'fa-sms' },
  { value: 'Email',       label: 'Email',       placeholder: 'contact@example.com', icon: 'fa-at' },
];

@Component({
  selector: 'app-contacts-table',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div [formGroup]="parentForm">
      <div formArrayName="contacts">
        <div class="row mb-2 align-items-end" *ngFor="let contact of contacts.controls; let i=index" [formGroupName]="i">
          <div class="col-md-3">
            <label *ngIf="i===0" class="form-label text-muted fw-bold small">Contact Type</label>
            <select class="form-select" formControlName="type"
              [class.is-invalid]="contact.get('type')?.invalid && contact.get('type')?.touched"
              (change)="onTypeChange(i)">
              <option [ngValue]="null" disabled>Select type</option>
              <option *ngFor="let ct of contactTypes" [ngValue]="ct.value">{{ ct.label }}</option>
            </select>
            <div class="invalid-feedback">Required.</div>
          </div>
          <div class="col-md-4">
            <label *ngIf="i===0" class="form-label text-muted fw-bold small">Contact Value</label>
            <div class="input-group">
              <span class="input-group-text"><i class="fas {{ getIcon(i) }}"></i></span>
              <input type="text" class="form-control" formControlName="value"
                [class.is-invalid]="contact.get('value')?.invalid && contact.get('value')?.touched"
                [placeholder]="getPlaceholder(i)">
            </div>
            <div class="invalid-feedback d-block"
              *ngIf="contact.get('value')?.invalid && contact.get('value')?.touched">Required.</div>
          </div>
          <div class="col-md-4">
            <label *ngIf="i===0" class="form-label text-muted fw-bold small">Contact Name / Label</label>
            <input type="text" class="form-control" formControlName="name" placeholder="e.g. Main Line, HR Dept...">
          </div>
          <div class="col-md-1 d-flex justify-content-end" [class.mt-3]="i===0">
            <button class="btn btn-icon text-danger" type="button" (click)="removeContact(i)">
              <i class="fas fa-trash"></i>
            </button>
          </div>
        </div>
      </div>
      <button class="btn btn-outline-teal btn-sm mt-2" type="button" (click)="addContact()">
        <i class="fas fa-plus"></i> Add Contact
      </button>
    </div>
  `
})
export class ContactsTableComponent {
  @Input() parentForm!: FormGroup;
  private fb = inject(FormBuilder);

  sweetAlert = inject(SweetAlertService);

  contactTypes = CONTACT_TYPES;

  get contacts() {
    return this.parentForm.get('contacts') as FormArray;
  }

  getTypeInfo(index: number) {
    const typeVal = this.contacts.at(index).get('type')?.value;
    return this.contactTypes.find(ct => ct.value === typeVal) || null;
  }

  getPlaceholder(index: number): string {
    return this.getTypeInfo(index)?.placeholder || 'Enter value...';
  }

  getIcon(index: number): string {
    return this.getTypeInfo(index)?.icon || 'fa-address-book';
  }

  onTypeChange(index: number) {
    // Force re-render by touching the control
    this.contacts.at(index).get('value')?.updateValueAndValidity();
  }

  addContact() {
    this.contacts.push(this.fb.group({
      type: [null, Validators.required],
      value: ['', Validators.required],
      name: ['']
    }));
  }

  async removeContact(index: number) {
    const confirmed = await this.sweetAlert.confirm(
      'Confirm',
      'Are you sure you want to delete item(s)?'
    );
    if (confirmed) {
      this.contacts.removeAt(index);
      this.sweetAlert.success('Success', 'Contact removed successfully');
    }
  }
}
