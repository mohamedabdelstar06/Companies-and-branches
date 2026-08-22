import { DatePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { CellParams } from '@app/core/grids/cell-params';

@Component({
  selector: 'app-date-cell',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './date-cell.component.html',
  styleUrl: './date-cell.component.scss'
})
export class DateCellComponent {
  @Input() context!: CellParams
}
