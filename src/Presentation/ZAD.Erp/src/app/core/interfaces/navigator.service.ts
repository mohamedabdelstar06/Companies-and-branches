import { Observable } from "rxjs";
import { IPageQuery } from "../service-proxies/service-proxies";

export interface INavigatorService {
    getFirst(pageQuery?: IPageQuery): Observable<any>
    getLast(pageQuery?: IPageQuery): Observable<any>
    getNext(currentId: number, pageQuery?: IPageQuery): Observable<any>
    getPrevious(currentId: number, pageQuery?: IPageQuery): Observable<any>
}
