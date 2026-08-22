import { Component, Input } from '@angular/core';
import { CellParams } from '@app/core/grids/cell-params';

@Component({
    selector: 'operation-header',
    standalone: true,
    templateUrl: './operation-header.renderer.html',
  styleUrl: './operation-header.renderer.scss',
})
export class OperationHeaderRenderer {
    @Input() context!: CellParams

    selectAll() {
        var field = this.context.field;
        var checkboxes = document.querySelectorAll<HTMLElement>(`input.operation[field="${field}"]`)
        checkboxes.forEach(x => x.click())
    }
}
