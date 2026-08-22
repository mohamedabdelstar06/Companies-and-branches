using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ZAD.Application.DTOs.Common;
using ZAD.Application.DTOs.VehicleRental.Contract;
using ZAD.Application.Exceptions;
using ZAD.Application.Interfaces.VehicleRental;
using ZAD.Domain.Entities.VehicleRental.Contracts;
using ZAD.Domain.Enums.VehicleRental;
using ZAD.Domain.Interfaces;

namespace ZAD.Application.Services.VehicleRental
{
    public class ContractService : IContractService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ContractService> _logger;

        public ContractService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ContractService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ContractDetailDto> CreateAsync(CreateContractDto dto)
        {
            var tenant = await _unitOfWork.Tenants.GetByIdAsync(dto.TenantId);
            if (tenant == null)
            {
                throw new NotFoundException($"Tenant with ID {dto.TenantId} not found.");
            }

            var age = Math.Max(0, (DateTime.Today - tenant.Birthday).Days / 365);
            if (age < 18 || age > 60)
            {
                throw new FluentValidation.ValidationException("Tenant age must be between 18 and 60 years old.");
            }

            var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(dto.RentalVehicleId);
            if (vehicle == null)
            {
                throw new NotFoundException($"Vehicle with ID {dto.RentalVehicleId} not found.");
            }
            if (vehicle.IsRented)
            {
                var activeContracts = await _unitOfWork.Contracts.GetAsync(c => c.RentalVehicleId == vehicle.Id && c.DeliveryStatus == DeliveryStatus.Rented);
                var latestContract = activeContracts.OrderByDescending(c => c.CreatedAt).FirstOrDefault();
                
                if (latestContract != null)
                {
                    throw new FluentValidation.ValidationException($"The car cannot be used in the current contract because it is under contract number '{latestContract.Id}', accounting no. '{latestContract.AccountingNo}'.");
                }
                else
                {
                    vehicle.SetRentedStatus(false);
                    _unitOfWork.RentalVehicles.Update(vehicle);
                }
            }
            decimal expectedMinimum = dto.ContractType switch
            {
                ContractType.Hourly => vehicle.HourlyRentPrice,
                ContractType.Daily => vehicle.DailyRentPrice,
                ContractType.Weekly => vehicle.WeeklyRentPrice,
                ContractType.Monthly => vehicle.MonthlyRentPrice,
                ContractType.LongTerm => vehicle.YearlyRentPrice,
                _ => 0
            };
            var discountAmount = dto.RentPrice * dto.DiscountPercent / 100m;
            var netRentPrice = dto.RentPrice - discountAmount;
            if (netRentPrice < expectedMinimum * dto.PeriodInDays)
            {
                throw new FluentValidation.ValidationException($"Net rent price ({netRentPrice}) is lower than the minimum allowed ({expectedMinimum * dto.PeriodInDays}) for this car and period.");
            }

            // In a real scenario, this would be generated safely
            var accountingNo = 1000 + new Random().Next(1000); 

            var contract = new Contract(
                dto.CompanyId, dto.BranchId, accountingNo, dto.Time, dto.Date, dto.ContractType, dto.PaymentType, dto.PeriodInDays,
                dto.ExpectedReceivingTime, dto.ExpectedReceivingDate, dto.WithDriver, dto.DriverId,
                dto.TenantId, dto.SponsorName, dto.SponsorNationality, dto.SponsorLicenseNumber, 
                dto.SponsorLicenseExpireDate, dto.SponsorIdNumber, dto.SponsorIdExpireDate,
                dto.SecondDriverName, dto.SecondDriverNationality, dto.SecondDriverLicenseNumber,
                dto.SecondDriverLicenseExpireDate, dto.SecondDriverIdNumber, dto.SecondDriverIdExpireDate,
                dto.RentalVehicleId, dto.KilometerCounter, dto.RentPrice, dto.DiscountPercent,
                dto.DelayPenaltyPerHour, dto.AllowedDelayHours, dto.MaintenancePenalty, dto.AccidentPenalty,
                dto.DriverFare, dto.DriverWorkingHoursPerDay, dto.DriverOvertimeAmountPerHour,
                dto.KilometerPerDay, dto.MaximumKilometerPerDay, dto.AmountOfKmExceedingLimit,
                DeliveryStatus.Rented, ContractStatus.Draft, false
            );

            await _unitOfWork.Contracts.AddAsync(contract);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ContractDetailDto>(contract);
        }

        public async Task<ContractDetailDto> UpdateAsync(UpdateContractDto dto)
        {
            var contract = await _unitOfWork.Contracts.GetByIdAsync(dto.Id);
            if (contract == null)
            {
                throw new NotFoundException($"Contract {dto.Id} not found.");
            }

            var tenant = await _unitOfWork.Tenants.GetByIdAsync(dto.TenantId);
            if (tenant == null)
            {
                throw new NotFoundException($"Tenant with ID {dto.TenantId} not found.");
            }

            var age = Math.Max(0, (DateTime.Today - tenant.Birthday).Days / 365);
            if (age < 18 || age > 60)
            {
                throw new FluentValidation.ValidationException("Tenant age must be between 18 and 60 years old.");
            }

            var vehicle = await _unitOfWork.RentalVehicles.GetByIdAsync(dto.RentalVehicleId);
            if (vehicle == null)
            {
                throw new NotFoundException($"Vehicle with ID {dto.RentalVehicleId} not found.");
            }
            if (vehicle.IsRented && contract.RentalVehicleId != dto.RentalVehicleId)
            {
                var activeContracts = await _unitOfWork.Contracts.GetAsync(c => c.RentalVehicleId == vehicle.Id && c.DeliveryStatus == DeliveryStatus.Rented);
                var latestContract = activeContracts.OrderByDescending(c => c.CreatedAt).FirstOrDefault();
                
                if (latestContract != null)
                {
                    throw new FluentValidation.ValidationException($"The car cannot be used in the current contract because it is under contract number '{latestContract.Id}', accounting no. '{latestContract.AccountingNo}'.");
                }
                else
                {
                    vehicle.SetRentedStatus(false);
                    _unitOfWork.RentalVehicles.Update(vehicle);
                }
            }
            decimal expectedMinimum = dto.ContractType switch
            {
                ContractType.Hourly => vehicle.HourlyRentPrice,
                ContractType.Daily => vehicle.DailyRentPrice,
                ContractType.Weekly => vehicle.WeeklyRentPrice,
                ContractType.Monthly => vehicle.MonthlyRentPrice,
                ContractType.LongTerm => vehicle.YearlyRentPrice,
                _ => 0
            };
            var discountAmount = dto.RentPrice * dto.DiscountPercent / 100m;
            var netRentPrice = dto.RentPrice - discountAmount;
            if (netRentPrice < expectedMinimum * dto.PeriodInDays)
            {
                throw new FluentValidation.ValidationException($"Net rent price ({netRentPrice}) is lower than the minimum allowed ({expectedMinimum * dto.PeriodInDays}) for this car and period.");
            }

            contract.Update(
                dto.CompanyId, dto.BranchId, contract.AccountingNo, dto.Time, dto.Date, dto.ContractType, dto.PaymentType, dto.PeriodInDays,
                dto.ExpectedReceivingTime, dto.ExpectedReceivingDate, dto.WithDriver, dto.DriverId,
                dto.TenantId, dto.SponsorName, dto.SponsorNationality, dto.SponsorLicenseNumber, 
                dto.SponsorLicenseExpireDate, dto.SponsorIdNumber, dto.SponsorIdExpireDate,
                dto.SecondDriverName, dto.SecondDriverNationality, dto.SecondDriverLicenseNumber,
                dto.SecondDriverLicenseExpireDate, dto.SecondDriverIdNumber, dto.SecondDriverIdExpireDate,
                dto.RentalVehicleId, dto.KilometerCounter, dto.RentPrice, dto.DiscountPercent,
                dto.DelayPenaltyPerHour, dto.AllowedDelayHours, dto.MaintenancePenalty, dto.AccidentPenalty,
                dto.DriverFare, dto.DriverWorkingHoursPerDay, dto.DriverOvertimeAmountPerHour,
                dto.KilometerPerDay, dto.MaximumKilometerPerDay, dto.AmountOfKmExceedingLimit,
                contract.DeliveryStatus, contract.Status, contract.IsPosted
            );

            _unitOfWork.Contracts.Update(contract);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ContractDetailDto>(contract);
        }

        public async Task<string> DeleteAsync(int id)
        {
            await _unitOfWork.Contracts.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return "Contract deleted successfully.";
        }

        public async Task<ContractDetailDto> GetAsync(int id)
        {
            var contract = await _unitOfWork.Contracts.GetByIdAsync(id);
            if (contract == null)
            {
                throw new NotFoundException($"Contract {id} not found.");
            }
            return _mapper.Map<ContractDetailDto>(contract);
        }

        public async Task<PageResult<ContractListDto>> GetPageAsync(PageQuery query)
        {
            var (items, totalCount) = await _unitOfWork.Contracts.GetPageWithContextAsync<ContractListDto>(
                query.PageIndex,
                query.PageSize,
                query.SearchTerm,
                query.SortColumn,
                query.SortDirection,
                query.CompanyId,
                query.BranchId);

            return new PageResult<ContractListDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageIndex = query.PageIndex,
                PageSize = query.PageSize
            };
        }

        public async Task<ContractDropdownsDto> GetDropdownsAsync()
        {
            var tenants = await _unitOfWork.Tenants.GetAsync(x => !x.IsDeleted);
            var drivers = await _unitOfWork.Drivers.GetAsync(x => !x.IsDeleted);
            var vehicles = await _unitOfWork.RentalVehicles.GetAsync(x => !x.IsDeleted);
            var companies = await _unitOfWork.Companies.GetAsync(x => !x.IsDeleted);
            var branches = await _unitOfWork.Branches.GetAsync(x => !x.IsDeleted);
            var sponsors = await _unitOfWork.Sponsors.GetAsync(x => !x.IsDeleted);
            var secondDrivers = await _unitOfWork.SecondDrivers.GetAsync(x => !x.IsDeleted);

            return new ContractDropdownsDto
            {
                Companies = companies.Select(c => new ZAD.Application.DTOs.Company.CompanyDropdownDto
                {
                    Id = c.Id,
                    Name = c.NameEn
                }),
                Branches = branches.Select(b => new ZAD.Application.DTOs.Branch.BranchDropdownDto
                {
                    Id = b.Id,
                    CompanyId = b.CompanyId,
                    Name = b.NameEn
                }),
                Tenants = tenants.Select(t => new ZAD.Application.DTOs.VehicleRental.Tenant.TenantDropdownDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Birthday = t.Birthday,
                    LicenseNumber = t.LicenseNumber,
                    PassportNumber = t.PassportNumber,
                    UnifiedNumber = t.UnifiedNumber,
                    IdNumber = t.IdNumber,
                    Mobile = t.Mobile
                }),
                Drivers = drivers.Select(d => new ZAD.Application.DTOs.VehicleRental.Driver.DriverDropdownDto
                {
                    Id = d.Id,
                    Name = d.Name
                }),
                Vehicles = vehicles.Select(v => new ZAD.Application.DTOs.VehicleRental.RentalVehicle.RentalVehicleDropdownDto
                {
                    Id = v.Id,
                    PlateNo = v.Brand + " - " + v.PlateNo,
                    Brand = v.Brand,
                    ModelYear = v.ModelYear,
                    FileNo = v.FileNo,
                    KilometerCounter = v.KilometerCounter,
                    Type = (int)v.Type,
                    TypeName = v.Type.ToString(),
                    HourlyRentPrice = v.HourlyRentPrice,
                    DailyRentPrice = v.DailyRentPrice,
                    WeeklyRentPrice = v.WeeklyRentPrice,
                    MonthlyRentPrice = v.MonthlyRentPrice,
                    YearlyRentPrice = v.YearlyRentPrice,
                    IsRented = v.IsRented
                }),
                Sponsors = sponsors.Select(s => new ZAD.Application.DTOs.VehicleRental.Sponsor.SponsorDropdownDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Nationality = s.Nationality,
                    LicenseNumber = s.LicenseNumber,
                    LicenseExpireDate = s.LicenseExpireDate,
                    IdNumber = s.IdNumber,
                    IdExpireDate = s.IdExpireDate
                }),
                SecondDrivers = secondDrivers.Select(sd => new ZAD.Application.DTOs.VehicleRental.Driver.SecondDriverDropdownDto
                {
                    Id = sd.Id,
                    Name = sd.Name,
                    Nationality = sd.Nationality,
                    LicenseNumber = sd.LicenseNumber,
                    LicenseExpireDate = sd.LicenseExpireDate,
                    IdNumber = sd.IdNumber,
                    IdExpireDate = sd.IdExpireDate
                })
            };
        }
    }
}
