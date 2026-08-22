import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { BehaviorSubject, Observable, catchError, filter, firstValueFrom, of, shareReplay, take, tap } from 'rxjs';
import { StyleService } from '../style/style.service';
import { CultureModel } from '../../models/common/culture.model';


@Injectable({
  providedIn: 'root',
})
export class CultureService {
  private readonly fallbackCultures: CultureModel[] = [
    { id: 1, code: 'en', name: 'English', flagCode: 'us', isDefault: true, isActive: true },
    { id: 1, code: 'ar', name: 'عربي', flagCode: 'eg', isDefault: false, isActive: true },
  ];
  private cultures: Observable<CultureModel[]>;
  private suppressFireChange = false;

  onCultureChange: EventEmitter<CultureModel> = new EventEmitter<CultureModel>();
  private cultureSubject = new BehaviorSubject<string>('en');
  culture$ = this.cultureSubject.asObservable();

  constructor(
    private httpClient: HttpClient,
    private styleService: StyleService,
    private translateService: TranslateService
  ) {
    translateService.setDefaultLang(this.fallbackCultures.filter((x) => x.isDefault)[0].code);

    this.cultures = this.httpClient.get<CultureModel[]>('/api/system/cultures').pipe(
      catchError(() => {
        return of(this.fallbackCultures);
      }),
      tap((result) => {
        translateService.addLangs(result.map((x) => x.code));

        const currentCultureCode = localStorage.getItem('culture') || 'en';
        let culture = result.find((x) => x.code === currentCultureCode);

        if (!culture) {
          culture = result.find((x) => x.isActive);
        }

        if (culture) {
          this.cultureSubject.next(culture.code);
          localStorage.setItem('culture', culture.code);
          this.changeCulture(culture, false);
          this.translateService.use(culture.code);
        }
      }),
      shareReplay(1)
    );

    this.translateService.onLangChange.subscribe(() => this.fireChange());
  }

  getCultures(): Observable<CultureModel[]> {
    return this.cultures;
  }

  translate(key: string | Array<string>, interpolateParams?: Object): string | any {
    return this.translateService.instant(key, interpolateParams);
  }

  get(key: string | Array<string>, interpolateParams?: Object): Observable<string | any> {
    return this.translateService.get(key, interpolateParams);
  }

  refreshCulture() {
    this.culture$
      .pipe(
        take(1),
        filter((x) => x != null && x != '')
      )
      .subscribe((culture: any) => {
        this.styleService.changeDirection(culture);
        this.translateService.use(culture);
      });
  }

  changeCulture(culture: CultureModel, fireChange: boolean = true) {
    this.suppressFireChange = fireChange;
    this.styleService.changeDirection(culture.code);
    this.translateService.use(culture.code);
  }

  private fireChange() {
    if (this.suppressFireChange) this.onCultureChange.emit();
  }

  isRtl() {
    return this.styleService.getDirection() == 'rtl';
  }
}
