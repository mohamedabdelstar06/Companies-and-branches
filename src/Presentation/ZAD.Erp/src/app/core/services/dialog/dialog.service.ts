import { Injectable, Type } from '@angular/core';
import { CultureService } from '../culture/culture.service';
import { AlertDialogConfigModel } from '../../models/common/dialog-config.model';
import { AlertDialogComponent } from '@app/shared/popups/alert-dialog/alert-dialog.component';
import { DynamicDialogConfig, DialogService as DynamicDialogService } from 'primeng/dynamicdialog';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(
    private modalService: DynamicDialogService,
    private cultureService: CultureService) { }

  open(template: Type<any>, config: DynamicDialogConfig = {}) {
    return this.modalService.open(template, {
      ...config,
      styleClass: 'message-modal',
      header: this.cultureService.translate(config.header!)
    });
  }

  confirmSave(onConfirm: () => void) {
    this.confirm('messages.confirm_save', onConfirm, 'success')
  }

  confirmTransaction(onConfirm: () => void) {
    this.confirm('messages.confirm_transaction', onConfirm, 'warning')
  }

  unconfirmTransaction(onConfirm: () => void) {
    this.confirm('messages.unconfirm_transaction', onConfirm, 'warning')
  }

  confirmActivate(onConfirm: () => void) {
    this.confirm('messages.confirm_activate', onConfirm, 'warning')
  }

  confirmDeactivate(onConfirm: () => void) {
    this.confirm('messages.confirm_deactivate', onConfirm, 'warning')
  }

  confirmDelete(onConfirm: () => void) {
    this.confirm('messages.confirm_delete', onConfirm)
  }

  confirmUndelete(onConfirm: () => void) {
    this.confirm('messages.confirm_undelete', onConfirm, 'warning')
  }

  confirm(message: string, onConfirm: () => void, type: string = 'danger') {
    this.alert({
      header: 'general.confirm',
      data: {
        message: message,
        iconClass: `fa-solid fa-circle-question text-${type}`,
        confirmButtonText: 'general.confirm',
        cancelButtonText: 'general.cancel',
        type: type,
        onConfirm: onConfirm
      }
    })
  }

  alert(config: AlertDialogConfigModel) {
    config.showHeader = false
    config.data.message = this.cultureService.translate(config.data.message)
    config.data.confirmButtonText = this.cultureService.translate(config.data.confirmButtonText || 'general.confirm')
    if (config.data.cancelButtonText || config.data.onCancel != null)
      config.data.cancelButtonText = this.cultureService.translate(config.data.cancelButtonText || 'general.cancel')
    config.closable = false
    this.open(AlertDialogComponent, config)
  }

  alertWithInput(config: AlertDialogConfigModel) {
    config.showHeader = false
    config.data.showInput = true;
    config.data.message = this.cultureService.translate(config.data.message);
    config.data.confirmButtonText = this.cultureService.translate(config.data.confirmButtonText || 'general.confirm');
    if (config.data.cancelButtonText || config.data.onCancel != null) {
      config.data.cancelButtonText = this.cultureService.translate(config.data.cancelButtonText || 'general.cancel');
    }
    config.closable = false;
    this.open(AlertDialogComponent, config);
  }
}
