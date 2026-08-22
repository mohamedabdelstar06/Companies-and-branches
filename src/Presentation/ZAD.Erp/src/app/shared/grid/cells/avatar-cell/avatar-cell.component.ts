import { Component, Input } from '@angular/core';
import { CellParams } from '@app/core/grids/cell-params';

@Component({
  selector: 'avatar-cell',
  standalone: true,
  imports: [],
  templateUrl: './avatar-cell.component.html',
  styleUrl: './avatar-cell.component.scss'
})
export class AvatarCellComponent {
  @Input() context!: CellParams
  image?: string;

  ngOnInit() {
    this.image = this.context.value ?? ''
  }
}
