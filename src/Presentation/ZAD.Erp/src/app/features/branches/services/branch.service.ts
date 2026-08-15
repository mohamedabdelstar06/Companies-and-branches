import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BranchDetailDto, BranchListDto } from '../models/branch.model';
import { PageQuery, PageResult } from '../../companies/models/company.model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BranchService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl + '/Branches';

  getPage(query: PageQuery): Observable<PageResult<BranchListDto>> {
    let params = new HttpParams()
      .set('pageNumber', query.pageNumber)
      .set('pageSize', query.pageSize);
    
    if (query.searchTerm) {
      params = params.set('searchTerm', query.searchTerm);
    }
    
    return this.http.get<PageResult<BranchListDto>>(this.apiUrl, { params });
  }

  getById(id: number): Observable<BranchDetailDto> {
    return this.http.get<BranchDetailDto>(`${this.apiUrl}/${id}`);
  }

  create(formData: FormData): Observable<BranchDetailDto> {
    return this.http.post<BranchDetailDto>(this.apiUrl, formData);
  }

  update(id: number, formData: FormData): Observable<BranchDetailDto> {
    return this.http.put<BranchDetailDto>(`${this.apiUrl}/${id}`, formData);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  toggleActive(id: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}/toggle-active`, {});
  }
}
