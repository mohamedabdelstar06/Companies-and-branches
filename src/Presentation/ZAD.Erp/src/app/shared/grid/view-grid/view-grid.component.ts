import { NgComponentOutlet, NgFor } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Column } from '@app/core/grids/column';
import { TranslateModule } from '@ngx-translate/core';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'view-grid',
  standalone: true,
  imports: [TableModule, TranslateModule, NgComponentOutlet, NgFor],
  templateUrl: './view-grid.component.html',
  styleUrl: './view-grid.component.scss'
})
export class ViewGridComponent {
  @Input({ required: true }) columns: Column[] = []
  @Input({ required: true }) rowData: any[] = []
}
