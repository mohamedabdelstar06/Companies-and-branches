import { NgTemplateOutlet } from '@angular/common';
import { Component, Input, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Permissions } from '@app/core/constants/claims';
import { AuthorizeDirective } from '@app/shared/directives/authorize.directive';
import { IndexToolbarService } from '@app/core/interfaces/index-toolbar.service';
import { DialogService } from '@app/core/services/dialog/dialog.service';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'view-toolbar',
  standalone: true,
  imports: [TranslateModule, AuthorizeDirective, NgTemplateOutlet],
  templateUrl: './view-toolbar.component.html',
  styleUrl: './view-toolbar.component.scss'
})
export class ViewToolbarComponent {
  @Input() currentId!: number
  @Input() toolbarService!: IndexToolbarService;
  @Input() claims!: Permissions

  @Input() isDeleted?: boolean

  @Input() isActive?: boolean
  @Input() deactivateButtonTemplate?: TemplateRef<any>;

  @Input() isConfirmed?: boolean
  @Input() unconfirmButtonTemplate?: TemplateRef<any>;

  constructor(
    private dialogService: DialogService,
    private activateRoute: ActivatedRoute,
    private router: Router) { }

  navigateToAdd() {
    this.router.navigate(['./add'], { relativeTo: this.activateRoute.parent });
  }

  navigateToEdit() {
    this.router.navigate(['./edit', this.currentId], { relativeTo: this.activateRoute.parent });
  }

  navigateToDuplicate() {
    this.router.navigate(['./duplicate', this.currentId], { relativeTo: this.activateRoute.parent });
  }

  navigateToIndex() {
    this.router.navigate(['./'], { relativeTo: this.activateRoute.parent });
  }

  delete() {
    this.dialogService.confirmDelete(() => {
      this.toolbarService.delete(this.currentId)
        .subscribe(() => this.isDeleted = true);
    })
  }

  undelete() {
    this.dialogService.confirmUndelete(() => {
      this.toolbarService.undelete!(this.currentId)
        .subscribe(() => this.isDeleted = false);
    })
  }

  activate() {
    this.dialogService.confirmActivate(() => {
      this.toolbarService.activate!(this.currentId)
        .subscribe(() => this.isActive = true);
    });
  }

  deactivate() {
    this.dialogService.confirmDeactivate(() => {
      this.toolbarService.deactivate!(this.currentId)
        .subscribe(() => this.isActive = false);
    });
  }

  confirm() {
    this.dialogService.confirmTransaction(() => {
      this.toolbarService.confirm!(this.currentId)
        .subscribe(() => this.isConfirmed = true);
    });
  }

  unconfirm() {
    this.dialogService.unconfirmTransaction(() => {
      this.toolbarService.unconfirm!(this.currentId)
        .subscribe(() => this.isConfirmed = false);
    });
  }
}
