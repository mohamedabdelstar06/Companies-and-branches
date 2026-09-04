import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CompanyDetailDto, CompanyListDto, PageQuery, PageResult } from '../models/company.model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl + '/Companies';

  getPage(query: PageQuery): Observable<PageResult<CompanyListDto>> {
    let params = new HttpParams()
      .set('pageNumber', query.pageNumber)
      .set('pageSize', query.pageSize);
    
    if (query.searchTerm) {
      params = params.set('searchTerm', query.searchTerm);
    }
    if (query.sortColumn) {
      params = params.set('sortColumn', query.sortColumn);
    }
    if (query.sortDirection) {
      params = params.set('sortDirection', query.sortDirection);
    }
    
    return this.http.get<PageResult<CompanyListDto>>(this.apiUrl, { params });
  }

  getById(id: number): Observable<CompanyDetailDto> {
    return this.http.get<CompanyDetailDto>(`${this.apiUrl}/${id}`);
  }

  create(formData: FormData): Observable<CompanyDetailDto> {
    return this.http.post<CompanyDetailDto>(this.apiUrl, formData);
  }

  update(id: number, formData: FormData): Observable<CompanyDetailDto> {
    return this.http.put<CompanyDetailDto>(`${this.apiUrl}/${id}`, formData);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  toggleActive(id: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}/toggle-active`, {});
  }
}
