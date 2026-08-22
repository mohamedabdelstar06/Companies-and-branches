import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CellParams } from '@app/core/grids/cell-params';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'lib-link-cell',
  standalone: true,
  imports: [TranslateModule, RouterLink],
  templateUrl: './link-cell.component.html',
  styleUrl: './link-cell.component.scss'
})
export class LinkCellComponent {
  @Input() context!: CellParams
  customLink: string | null = null

  ngOnInit() {
    this.customLink = this.getCustomLink()
  }

  private getCustomLink() {
    var link = this.context.params?.link
    if (typeof link == "function")
      return link(this.context.row)
    return link
  }
}
