import { NgFor, NgTemplateOutlet } from '@angular/common';
import { Component, inject, Input } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { CellParams } from '@app/core/grids/cell-params';
import { AuthorizeDirective } from '@app/shared/directives/authorize.directive';
import { DialogService } from '@app/core/services/dialog/dialog.service';
import { IndexToolbarService } from '@app/core/interfaces/index-toolbar.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'action-cell',
  standalone: true,
  imports: [TranslateModule, RouterLink, NgTemplateOutlet, AuthorizeDirective, NgFor],
  templateUrl: './action-cell.component.html',
  styleUrl: './action-cell.component.scss'
})
export class ActionCellComponent {
  @Input() context!: CellParams
  row: any
  viewOnly = false
  customActions: any[] = []
  claims: any = {}
  toolbarService?: IndexToolbarService
  hasDefaultActions = false

  private router = inject(Router)
  private activatedRoute = inject(ActivatedRoute)
  private dialogService = inject(DialogService)

  ngOnInit() {
    this.row = this.context.row
    this.claims = this.context.params.claims
    this.viewOnly = this.row.isSystem == undefined ? false : this.row.isSystem
    this.customActions = this.context.params.customActions || []
    this.toolbarService = this.context.params.toolbarService
    this.hasDefaultActions = this.toolbarService !== undefined
  }

  navigateToView() {
    this.router.navigate(['view', this.row.id], { relativeTo: this.activatedRoute.parent });
  }

  delete() {
    this.dialogService.confirmDelete(() => {
      this.toolbarService!.delete(this.row.id)
        .subscribe(() => this.row.isDeleted = true)
    })
  }

  undelete() {
    this.dialogService.confirmUndelete(() => {
      this.toolbarService!.undelete!(this.row.id)
        .subscribe(() => this.row.isDeleted = false);
    })
  }

  activate() {
    this.dialogService.confirmActivate(() => {
      this.toolbarService!.activate!(this.row.id)
        .subscribe(() => this.row.isActive = true);
    });
  }

  deactivate() {
    this.dialogService.confirmDeactivate(() => {
      this.toolbarService!.deactivate!(this.row.id)
        .subscribe(() => this.row.isActive = false);
    });
  }

  confirm() {
    this.dialogService.confirmTransaction(() => {
      this.toolbarService!.confirm!(this.row.id)
        .subscribe(() => this.row.isConfirmed = true);
    });
  }

  unconfirm() {
    this.dialogService.unconfirmTransaction(() => {
      this.toolbarService!.unconfirm!(this.row.id)
        .subscribe(() => this.row.isConfirmed = false);
    });
  }
}
