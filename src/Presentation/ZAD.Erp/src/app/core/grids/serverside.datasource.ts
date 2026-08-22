import { BehaviorSubject, finalize } from "rxjs";
import { ServerSideSourceService } from "../interfaces/serverside-source.service";

export class ServerSideDataSource {

    private dataSubject = new BehaviorSubject<any[]>([]);
    private loadingSubject = new BehaviorSubject<boolean>(false);
    private totalCountSubject = new BehaviorSubject<number>(0);

    public data$ = this.dataSubject.asObservable();
    public loading$ = this.loadingSubject.asObservable();
    public totalCount$ = this.totalCountSubject.asObservable();
    private lastQuery?: any;

    constructor(
        private source: ServerSideSourceService) { }

    disconnect(): void {
        this.dataSubject.complete();
        this.loadingSubject.complete();
    }

    reload() {
        if (this.lastQuery != null)
            this.load(this.lastQuery)
    }

    load(query: any) {
        this.lastQuery = query;
        this.loadingSubject.next(true);

        this.source.getPage(query).pipe(
            finalize(() => {
                this.loadingSubject.next(false)
            })
        )
            .subscribe({
                next: result => {
                    this.dataSubject.next(result.items)
                    this.totalCountSubject.next(result.totalCount)
                },
                error: () => []
            });
    }
}
