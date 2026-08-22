import { AsyncPipe, NgComponentOutlet, NgFor, NgIf } from '@angular/common';
import { Component, EventEmitter, inject, Input, Output, ViewChild } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Column } from '@app/core/grids/column';
import { ServerSideDataSource } from '@app/core/grids/serverside.datasource';

import { TranslateModule } from '@ngx-translate/core';
import { ProgressBarModule } from 'primeng/progressbar';
import { Table, TableLazyLoadEvent, TableModule } from 'primeng/table';
import { fromEvent, map, debounceTime, distinctUntilChanged, tap, take, Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'index-grid',
  standalone: true,
  imports: [TableModule, ProgressBarModule, TranslateModule, NgComponentOutlet, NgIf, NgFor, AsyncPipe],
  templateUrl: './index-grid.component.html',
  styleUrl: './index-grid.component.scss'
})
export class IndexGridComponent {
  @ViewChild(Table) table!: Table;
  @Input({ required: true }) searchInput!: HTMLInputElement
  @Input({ required: true }) datasource!: ServerSideDataSource
  @Input({ required: true }) columns: Column[] = []
  @Output() onSelectionChanged = new EventEmitter<any>()

  private destroyed$ = new Subject<void>()

  ngOnInit() {
  }

  ngOnDestroy() {
    this.destroyed$.next()
    this.destroyed$.complete()
  }

  ngAfterViewInit() {
    if (this.searchInput)
      fromEvent(this.searchInput, 'input').pipe(
        takeUntil(this.destroyed$),
        map(e => (e.target as HTMLInputElement).value),
        debounceTime(350),
        distinctUntilChanged(),
        tap(() => this.table.reset())
      ).subscribe()
  }

  onLazyLoad(evt: TableLazyLoadEvent) {
    this.datasource.load({
      pageIndex: evt.first! / evt.rows!,
      pageSize: evt.rows!,
      sortColumn: evt.sortField,
      sortDirection: evt.sortOrder,
      searchTerm: this.searchInput.value
    })
  }
}
