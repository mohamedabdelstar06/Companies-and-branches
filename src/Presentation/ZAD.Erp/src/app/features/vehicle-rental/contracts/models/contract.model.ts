export interface ContractListDto {
  id: number;
  accountingNo: number;
  companyId?: number;
  branchId?: number;
  companyName: string;
  branchName: string;
  plateNo: string;
  brand: string;
  date: string;
  toDate: string;
  periodInDays: number;
  actualPeriodInDays: number;
  contractType: string;
  tenantName: string;
  remainingAmount: number;
  deliveryStatus: string;

  status: string;
}

export interface ContractDetailDto {
  id: number;
  companyId?: number;
  companyName?: string;
  branchId?: number;
  branchName?: string;

  accountingNo: number;
  referenceNo?: string;

  time: string;
  date: string;
  day?: string;

  contractType: number;
  contractTypeName?: string;

  paymentType: number;
  paymentTypeName?: string;

  periodInDays: number;
  actualPeriodInDays: number;

  expectedReceivingTime: string;
  expectedReceivingDate: string;
  expectedReceivingDay?: string;

  withDriver: boolean;
  driverId?: number;
  driverName?: string;

  // Status
  status?: string;
  deliveryStatus?: string;

  remainingAmount: number;

  // Tenant
  tenantId: number;
  tenantName?: string;

  // Sponsor
  sponsorName?: string;
  sponsorNationality?: string;
  sponsorLicenseNumber?: string;
  sponsorLicenseExpireDate?: string;
  sponsorIdNumber?: string;
  sponsorIdExpireDate?: string;

  // Second Driver
  secondDriverName?: string;
  secondDriverNationality?: string;
  secondDriverLicenseNumber?: string;
  secondDriverLicenseExpireDate?: string;
  secondDriverIdNumber?: string;
  secondDriverIdExpireDate?: string;

  // Vehicle
  rentalVehicleId: number;
  plateNo?: string;
  brand?: string;
  modelYear?: number;
  fileNo?: string;
  kilometerCounter: number;
  rentPrice: number;
  discountPercent: number;
  discountAmount: number;
  netRentPrice: number;

  // Penalties
  delayPenaltyPerHour: number;
  allowedDelayHours: number;
  maintenancePenalty: number;
  accidentPenalty: number;

  // Private Driver
  driverFare: number;
  driverWorkingHoursPerDay: number;
  driverOvertimeAmountPerHour: number;
  dailyRate: number;

  // KM / Day
  kilometerPerDay: number;
  maximumKilometerPerDay: number;
  amountOfKmExceedingLimit: number;

  // Metadata
  createdAt?: string;
  updatedAt?: string;
}
