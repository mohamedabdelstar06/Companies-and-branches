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
  templateUrl: './contacts-table.component.html',
  styleUrl: './contacts-table.component.scss',})
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
