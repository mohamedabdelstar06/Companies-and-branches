import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments/environment';
import { TenantListDto, TenantDropdownDto, CreateTenantDto } from '../models/tenant.model';
import { PageResult } from '../../../companies/models/company.model';

@Injectable({
  providedIn: 'root'
})
export class TenantService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl + '/Tenants';

  getPage(query: any): Observable<PageResult<TenantListDto>> {
    const pageNumber = (query.pageIndex != null ? query.pageIndex + 1 : query.pageNumber) || 1;
    let params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', query.pageSize || 10);
    
    if (query.searchTerm) {
      params = params.set('searchTerm', query.searchTerm);
    }
    
    return this.http.get<PageResult<TenantListDto>>(this.apiUrl, { params });
  }

  getDropdown(): Observable<TenantDropdownDto[]> {
    return this.http.get<TenantDropdownDto[]>(`${this.apiUrl}/dropdown`);
  }

  create(dto: CreateTenantDto): Observable<TenantListDto> {
    return this.http.post<TenantListDto>(this.apiUrl, dto);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  // Toolbar methods
  deleteBulk(ids: number[]): Observable<any> {
    return this.http.post(`${this.apiUrl}/bulk-delete`, ids);
  }

  print(ids?: number[]): Observable<any> {
    return this.http.post(`${this.apiUrl}/print`, ids);
  }

  exportToExcel(): Observable<any> {
    return this.http.get(`${this.apiUrl}/export-excel`, { responseType: 'blob' });
  }
}
