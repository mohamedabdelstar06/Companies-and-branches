import { Component, Input } from '@angular/core';
import { NgIf } from '@angular/common';
import { CellParams } from '@app/core/grids/cell-params';

@Component({
  selector: 'operation-checkbox',
  standalone: true,
  imports: [NgIf],
  templateUrl: './operation-checkbox.renderer.html',
  styleUrl: './operation-checkbox.renderer.scss',
})
export class OperationCheckboxRenderer {
  @Input() context!: CellParams
  hasOperation: boolean = false

  ngOnInit() {
    this.hasOperation = this.context.row.operations
      .filter((x: any) => x.claimValue.split('.')[2] == this.context.field).length != 0
  }

  isChecked() {
    var operation = this.context.row.operations
      .find((x: any) => x.claimValue.split('.')[2] == this.context.field)
    return operation?.checked
  }

  togglePermission(event: any) {
    var checked = event.currentTarget.checked
    var operation = this.context.row.operations
      .find((x: any) => x.claimValue.split('.')[2] == this.context.field)
    if (operation) {
      operation.checked = checked
      this.context.row[this.context.field] = checked
    }
  }
}
