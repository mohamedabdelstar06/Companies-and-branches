import { Observable } from "rxjs";

export interface IndexToolbarService {
    delete(id: number): Observable<any>
    deleteBulk(ids: number[]): Observable<any>

    undelete?(id: number): Observable<any>
    undeleteBulk?(ids: number[]): Observable<any>

    activate?(id: number): Observable<any>
    activateBulk?(ids: number[]): Observable<any>

    deactivate?(id: number, comment?: any): Observable<any>
    deactivateBulk?(ids: number[], comment?: any): Observable<any>

    confirm?(id: number): Observable<any>
    confirmBulk?(ids: number[]): Observable<any>

    unconfirm?(id: number, comment?: any): Observable<any>
    unconfirmBulk?(ids: number[], comment?: any): Observable<any>

    print(): Observable<any>
    exportToExcel(): Observable<any>
}
