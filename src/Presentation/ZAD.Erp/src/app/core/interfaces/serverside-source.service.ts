import { Observable } from "rxjs";
import { PageResult } from "../models/common/page-result.model";

export interface ServerSideSourceService {
    getPage(query: any): Observable<PageResult<any>>
}
