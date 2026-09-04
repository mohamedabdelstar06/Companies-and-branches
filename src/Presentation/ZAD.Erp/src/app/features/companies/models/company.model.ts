export interface ContactDto {
  id?: number;
  type: string;
  value: string;
  name: string;
}

export interface DocumentDto {
  id?: number;
  type: string;
  documentNumber: string;
  attachFile?: string | File;
  filePath?: string;
  expiryDate?: string;
}

export interface CompanyListDto {
  id: number;
  code: string;
  name: string;
  address: string;
  website: string;
  phone: string;
  logo: string;
  isActive: boolean;
}

export interface CompanyDetailDto {
  id: number;
  code: string;
  nameAr: string;
  nameEn: string;
  country: string;
  city: string;
  addressAr: string;
  addressEn: string;
  nationality: string;
  language: string;
  logoPath: string;
  isActive: boolean;
  createdAt?: string;
  updatedAt?: string;
  contacts: ContactDto[];
  documents: DocumentDto[];
}

export interface PageQuery {
  pageNumber: number;
  pageSize: number;
  searchTerm?: string;
  sortColumn?: string;
  sortDirection?: string;
}

export interface PageResult<T> {
  items: T[];
  totalCount: number;
  pageNumber: number;
  pageSize: number;
}
