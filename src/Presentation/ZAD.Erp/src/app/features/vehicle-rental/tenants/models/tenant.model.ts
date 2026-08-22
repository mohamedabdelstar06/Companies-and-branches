export interface TenantListDto {
  id: number;
  name: string;
  licenseNumber: string;
  mobile: string;
  birthday: string;
  age: number;
}

export interface TenantDropdownDto {
  id: number;
  name: string;
  birthday: string;
  age: number;
}

export interface CreateTenantDto {
  name: string;
  licenseNumber: string;
  passportNumber: string;
  unifiedNumber: string;
  idNumber: string;
  mobile: string;
  birthday: string;
}
