import { Component, EventEmitter, Input, Output, TemplateRef } from "@angular/core";
import { TranslateModule } from "@ngx-translate/core";
import { RouterLink } from "@angular/router";
import { NgTemplateOutlet } from "@angular/common";
import { IndexToolbarService } from "../../core/interfaces/index-toolbar.service";
import { DialogService } from "../../core/services/dialog/dialog.service";
import { Permissions } from "@app/core/constants/claims";
import { AuthorizeDirective } from "@app/shared/directives/authorize.directive";

@Component({
  selector: "index-toolbar",
  standalone: true,
  imports: [TranslateModule, NgTemplateOutlet, AuthorizeDirective, RouterLink],
  templateUrl: "./index-toolbar.component.html",
  styleUrl: "./index-toolbar.component.scss",
})
export class IndexToolbarComponent {
  @Output() refresh = new EventEmitter<any>();
  @Input() selectedRows: any[] = [];
  @Input() toolbarService!: IndexToolbarService;
  @Input() claims!: Permissions;
  @Input() createButtonTemplate?: TemplateRef<any>;
  @Input() deactivateButtonTemplate?: TemplateRef<any>;
  @Input() unconfirmButtonTemplate?: TemplateRef<any>;
  isConfirm = false;

  constructor(private dialogService: DialogService) { }

  ngOnInit() {
    this.isConfirm = this.toolbarService.confirm !== undefined;
  }

  deleteBulk() {
    this.dialogService.confirmDelete(() => {
      this.toolbarService.deleteBulk(this.selectedRows.map((x) => x.id)).subscribe(() => this.refresh.emit());
    });
  }

  undeleteBulk() {
    this.dialogService.confirmUndelete(() => {
      this.toolbarService.undeleteBulk!(this.selectedRows.map((x) => x.id)).subscribe(() => this.refresh.emit());
    });
  }

  activateBulk() {
    this.dialogService.confirmActivate(() => {
      this.toolbarService.activateBulk!(this.selectedRows.map((x) => x.id)).subscribe(() => this.refresh.emit());
    });
  }

  deactivateBulk() {
    this.dialogService.confirmDeactivate(() => {
      this.toolbarService.deactivateBulk!(this.selectedRows.map((x) => x.id)).subscribe(() => this.refresh.emit());
    });
  }

  confirmBulk() {
    this.dialogService.confirmTransaction(() => {
      this.toolbarService.confirmBulk!(this.selectedRows.map((x) => x.id)).subscribe(() => this.refresh.emit());
    });
  }

  unconfirmBulk() {
    this.dialogService.unconfirmTransaction(() => {
      this.toolbarService.unconfirmBulk!(this.selectedRows.map((x) => x.id)).subscribe(() => this.refresh.emit());
    });
  }

  print() {
    this.toolbarService.print().subscribe();
  }

  exportToExcel() {
    this.toolbarService.exportToExcel().subscribe();
  }
}
