import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments/environment';

export interface DropdownDto {
    id: number;
    name?: string;
    plateNo?: string;
    modelYear?: number;
    fileNo?: string;
    kilometerCounter?: number;
    
    // Driver fields
    driverFare?: number;
    driverWorkingHoursPerDay?: number;
    driverOvertimeAmountPerHour?: number;
    nationality?: string;
    licenseNumber?: string;
    licenseExpireDate?: string;
    idNumber?: string;
    idExpireDate?: string;
    dailyRate?: number;
}

@Injectable({
  providedIn: 'root'
})
export class VehicleRentalLookupService {
  private http = inject(HttpClient);

  getDriversDropdown(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${environment.apiUrl}/Drivers/dropdown`);
  }

  getRentalVehiclesDropdown(): Observable<DropdownDto[]> {
    return this.http.get<DropdownDto[]>(`${environment.apiUrl}/RentalVehicles/dropdown`);
  }
}
