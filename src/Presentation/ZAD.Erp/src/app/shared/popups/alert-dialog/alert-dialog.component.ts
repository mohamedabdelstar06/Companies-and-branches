import { Component, Input } from '@angular/core';
import { AlertDialogConfigModel, AlertDialogDataModel } from '../../../core/models/common/dialog-config.model';
import { FormsModule } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'lib-alert-dialog',
  standalone: true,
  templateUrl: './alert-dialog.component.html',
  styleUrls: ['./alert-dialog.component.scss'],
  imports: [FormsModule]
})
export class AlertDialogComponent {
  typeClass: string = '';
  iconClass: string = '';

  constructor(
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig<AlertDialogDataModel>) {
  }

  ngOnInit() {
    if (this.config.data!.type === 'danger') {
      this.typeClass = 'danger';
      this.iconClass = 'fa-solid fa-circle-exclamation';
    } else if (this.config.data!.type === 'warning') {
      this.typeClass = 'warning';
      this.iconClass = 'fa-solid fa-circle-exclamation';
    } else if (this.config.data!.type === 'info') {
      this.typeClass = 'info';
      this.iconClass = 'fa-solid fa-circle-exclamation';
    } else if (this.config.data!.type === 'success') {
      this.typeClass = 'primary';
      this.iconClass = 'fa-solid fa-check-circle';
    }
  }

  confirm() {
    if (this.config.data!.onConfirm) {
      this.config.data!.onConfirm(this.config.data!.inputValue);
    }
    this.ref.close();
  }

  cancel() {
    if (this.config.data!.onCancel) {
      this.config.data!.onCancel();
    }
    this.ref.close();
  }
}
