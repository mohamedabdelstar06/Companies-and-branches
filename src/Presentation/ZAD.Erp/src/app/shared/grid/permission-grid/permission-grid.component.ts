import { Component, Input, ViewChild } from '@angular/core';
import { OperationCheckboxRenderer } from './operation-checkbox.renderer';
import { OperationHeaderRenderer } from './operation-header.renderer';
import { CultureService } from '@app/core/services/culture/culture.service';
import { Helper } from '@app/core/common/helper';
import { PageOperationDto } from '@app/core/service-proxies/service-proxies';
import { Table, TableModule } from 'primeng/table';
import { Column } from '@app/core/grids/column';
import { NgComponentOutlet, NgFor } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'permission-grid',
  standalone: true,
  imports: [TableModule, TranslateModule, NgComponentOutlet, NgFor],
  templateUrl: './permission-grid.component.html',
  styleUrl: './permission-grid.component.scss'
})
export class PermissionGridComponent {
  @ViewChild(Table) table!: Table;
  @Input() disabled: boolean = false;

  columns: Column[] = []
  rowData: any[] = []
  isRtl = false

  constructor(private cultureService: CultureService) { }

  selectClaims(claims: string[], reset: boolean = false) {
    if (reset) {
      this.rowData.forEach(page => {
        page.operations.forEach((op: any) => {
          var operation = op.claimValue.split('.')[2]
          page[operation] = false
        })
      })
    }

    claims.forEach(claim => {
      var page = this.rowData.find(x => claim.includes(x.claimValue));
      var operation = claim.split('.')[2]
      page[operation] = true
    })
  }

  getClaims() {
    var claims: any[] = []
    this.rowData.forEach(x => {
      var selected = x.operations.filter((y: any) => x[y.operationId])
      claims.push(selected.map((y: any) => ({ claimValue: y.claimValue })))
    })
    return claims.flat()
  }

  initGrid(pages: PageOperationDto[] = []) {
    var operations = pages
      .map(x => ({ order: x.operationId, id: x.claimValue!.split('.')[2], name: x.operationName }))
      .reduce((acc: any[], curr: any) => {
        if (!acc.find(x => x.id == curr.id))
          acc.push(curr)
        return acc;
      }, [])

    var pageGroup = Helper.groupBy(pages, 'pageName');
    this.rowData = Object.keys(pageGroup).map(x => ({
      moduleName: pageGroup[x][0].moduleName,
      pageName: pageGroup[x][0].pageName,
      claimValue: pageGroup[x][0].claimValue.split('.').splice(0, 2).join('.'),
      operations: pageGroup[x].map((y: PageOperationDto) => ({
        operationId: y.claimValue!.split('.')[2],
        operationName: y.operationName,
        claimValue: y.claimValue
      }))
    }));

    this.rowData.forEach(row => {
      row.operations.forEach((op: any) => row[op.operationId] = false)
    })
    
    this.columns = [
      {
        field: 'moduleName',
        header: this.cultureService.translate('general.module_name'),
      },
      {
        field: 'pageName',
        header: this.cultureService.translate('general.page_name'),
      },
      ...operations.sort((a: any, b: any) => a.order - b.order).map(x => ({
        field: x.id,
        header: x.name,
        component: OperationCheckboxRenderer,
        headerComponent: OperationHeaderRenderer,
        params: {
          disabled: this.disabled
        }
      })),
    ]
  }
}
