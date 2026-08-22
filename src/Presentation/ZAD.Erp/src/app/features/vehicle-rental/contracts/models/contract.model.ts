export interface ContractListDto {
  id: number;
  date: string;
  contractType: string;
  tenantName: string;
  plateNo: string;
  periodInDays: number;
  netRentPrice: number;
}

export interface ContractDetailDto {
  id: number;
  time: string;
  date: string;
  contractType: string;
  periodInDays: number;
  actualPeriodInDays: number;
  expectedReceivingTime: string;
  expectedReceivingDate: string;
  withDriver: boolean;
  driverId?: number;
  driverName?: string;
  
  tenantId: number;
  tenantName?: string;
  
  sponsorName?: string;
  sponsorNationality?: string;
  sponsorLicenseNumber?: string;
  sponsorLicenseExpireDate?: string;
  sponsorIdNumber?: string;
  sponsorIdExpireDate?: string;

  rentalVehicleId: number;
  plateNo?: string;
  modelYear?: number;
  fileNo?: string;
  kilometerCounter: number;
  rentPrice: number;
  discountPercent: number;
  discountAmount: number;
  netRentPrice: number;

  delayPenaltyPerHour: number;
  allowedDelayHours: number;
  maintenancePenalty: number;
  accidentPenalty: number;

  driverFare: number;
  driverWorkingHoursPerDay: number;
  driverOvertimeAmountPerHour: number;
  dailyRate: number;

  kilometerPerDay: number;
  maximumKilometerPerDay: number;
  amountOfKmExceedingLimit: number;

  nextMaintenanceDate: string;
  nextMaintenanceKm: number;
  reminderBeforePeriodicMaintenance: boolean;
  notificationType?: string;
}
