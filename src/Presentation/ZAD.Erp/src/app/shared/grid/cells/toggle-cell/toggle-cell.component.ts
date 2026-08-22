import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CellParams } from '@app/core/grids/cell-params';

@Component({
  selector: 'toggle-cell',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './toggle-cell.component.html',
  styleUrl: './toggle-cell.component.scss'
})
export class ToggleCellComponent {
  @Input() context!: CellParams
  checked = false

  ngOnInit() {
    this.checked = this.context.value
  }

  onChange(newValue: boolean) {
    this.fireCallback(newValue);
  }

  private fireCallback(newValue: boolean) {
    var onchange = this.context.params?.onchange;
    if (onchange != null) {
      onchange({ row: this.context.row, value: this.checked });
      setTimeout(() => this.checked = !newValue);
    }
  }
}
