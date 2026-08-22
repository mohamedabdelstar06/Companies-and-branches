import { Type } from "@angular/core";
import { ColumnFilterComponent } from "./column-filter.component";

export interface Column {
    header: string;
    field?: string;
    sortField?: string;
    component?: Type<any>;
    headerComponent?: Type<any>;
    filterComponent?: Type<ColumnFilterComponent>;
    params?: any;
    sortable?: boolean;
    width?: number;
}
