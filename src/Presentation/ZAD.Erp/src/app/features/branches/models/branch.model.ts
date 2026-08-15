export interface BranchListDto {
  id: number;
  code: string;
  name: string;
  companyName: string;
  address: string;
  website: string;
  phone: string;
  logo: string;
  isActive: boolean;
}

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

export interface BranchDetailDto {
  id: number;
  code: string;
  nameAr: string;
  nameEn: string;
  companyId: number;
  companyName: string;
  country: string;
  city: string;
  addressAr: string;
  addressEn: string;
  costCenter: string;
  isMainBranch: boolean;
  logoPath: string;
  isActive: boolean;
  createdAt?: string;
  updatedAt?: string;
  contacts: ContactDto[];
  documents: DocumentDto[];
}
