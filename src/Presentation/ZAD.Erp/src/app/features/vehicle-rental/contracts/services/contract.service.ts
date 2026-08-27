import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../../../environments/environment';
import { ContractListDto, ContractDetailDto } from '../models/contract.model';
import { PageResult } from '../../../companies/models/company.model';
import { VehicleRentalContextService } from '../../shared/services/vehicle-rental-context.service';

@Injectable({
  providedIn: 'root'
})
export class ContractService {
  private http = inject(HttpClient);
  private contextService = inject(VehicleRentalContextService);
  private apiUrl = environment.apiUrl + '/Contracts';

  getPage(query: any): Observable<PageResult<ContractListDto>> {
    const pageNumber = (query.pageIndex != null ? query.pageIndex + 1 : query.pageNumber) || 1;
    let params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', query.pageSize || 10);
    
    if (query.searchTerm) {
      params = params.set('searchTerm', query.searchTerm);
    }

    const context = this.contextService.getContext();
    if (context.companyId) {
      params = params.set('companyId', context.companyId);
    }
    if (context.branchId) {
      params = params.set('branchId', context.branchId);
    }
    
    return this.http.get<PageResult<ContractListDto>>(this.apiUrl, { params });
  }

  getById(id: number): Observable<ContractDetailDto> {
    return this.http.get<ContractDetailDto>(`${this.apiUrl}/${id}`);
  }

  getDropdowns(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/dropdowns`).pipe(
      map(res => {
       if (!res.drivers || res.drivers.length === 0) {
          res.drivers = [
            { id: 1, name: 'أحمد محمد' },
            { id: 2, name: 'محمود علي' },
            { id: 3, name: 'مصطفى كمال' },
            { id: 4, name: 'عبدالله إبراهيم' },
            { id: 5, name: 'يوسف حسن' },
            { id: 6, name: 'عمر سعيد' },
            { id: 7, name: 'طارق طه' },
            { id: 8, name: 'خالد سالم' },
            { id: 9, name: 'حسن عبدالرحمن' },
            { id: 10, name: 'وليد سامي' }
          ];
        }
        return res;
      })
    );
  }

  create(dto: any): Observable<ContractDetailDto> {
    return this.http.post<ContractDetailDto>(this.apiUrl, dto);
  }

  update(id: number, dto: any): Observable<ContractDetailDto> {
    return this.http.put<ContractDetailDto>(`${this.apiUrl}/${id}`, dto);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  restore(id: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/${id}/restore`, {});
  }

  confirm(id: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/${id}/confirm`, {});
  }

  unconfirm(id: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/${id}/unconfirm`, {});
  }

  receiveVehicle(id: number, payload: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/${id}/receive-vehicle`, payload);
  }

  unreceiveVehicle(id: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/${id}/unreceive-vehicle`, {});
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

