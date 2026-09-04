import { Component, EventEmitter, Input, Output, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.scss'
})
export class PaginationComponent implements OnChanges {
  @Input() pageNumber: number = 1;
  @Input() pageSize: number = 10;
  @Input() totalCount: number = 0;
  @Input() pageSizeOptions: number[] = [5, 10, 20, 50, 100];

  @Output() pageChanged = new EventEmitter<number>();
  @Output() pageSizeChanged = new EventEmitter<number>();

  pages: number[] = [];
  totalPages: number = 0;

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['totalCount'] || changes['pageSize'] || changes['pageNumber']) {
      this.calculatePages();
    }
  }

  calculatePages() {
    this.totalPages = Math.ceil(this.totalCount / this.pageSize);
    const maxPagesToShow = 5;
    const half = Math.floor(maxPagesToShow / 2);
    
    let start = Math.max(1, this.pageNumber - half);
    let end = Math.min(this.totalPages, start + maxPagesToShow - 1);
    
    if (end - start + 1 < maxPagesToShow) {
      start = Math.max(1, end - maxPagesToShow + 1);
    }
    
    this.pages = [];
    for (let i = start; i <= end; i++) {
      this.pages.push(i);
    }
  }

  changePage(page: number) {
    if (page >= 1 && page <= this.totalPages && page !== this.pageNumber) {
      this.pageChanged.emit(page);
    }
  }

  onPageSizeChange(size: number) {
    // Cast to number since HTML select binding might yield string
    this.pageSizeChanged.emit(Number(size));
  }

  get minRecord(): number {
    if (this.totalCount === 0) return 0;
    return (this.pageNumber - 1) * this.pageSize + 1;
  }

  get maxRecord(): number {
    return Math.min(this.pageNumber * this.pageSize, this.totalCount);
  }
}
