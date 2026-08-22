using FluentValidation;
using ZAD.Application.DTOs.VehicleRental.Contract;

namespace ZAD.Application.Validators.VehicleRental
{
    public class UpdateContractDtoValidator : AbstractValidator<UpdateContractDto>
    {
        public UpdateContractDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.TenantId).GreaterThan(0);
            RuleFor(x => x.RentalVehicleId).GreaterThan(0);
            RuleFor(x => x.PeriodInDays).GreaterThan(0);
            RuleFor(x => x.RentPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.DiscountPercent).InclusiveBetween(0, 100);
            
            When(x => !string.IsNullOrEmpty(x.SponsorName), () =>
            {
                RuleFor(x => x.SponsorName).NotEmpty().WithMessage("Sponsor name is required");
                RuleFor(x => x.SponsorNationality).NotEmpty().WithMessage("Nationality is required");
                RuleFor(x => x.SponsorLicenseNumber).NotEmpty().WithMessage("License number is required");
                RuleFor(x => x.SponsorLicenseExpireDate).NotEmpty().WithMessage("License expire date is required");
                RuleFor(x => x.SponsorIdNumber).NotEmpty().WithMessage("ID Number is required");
                RuleFor(x => x.SponsorIdExpireDate).NotEmpty().WithMessage("ID expire date is required"); 
            });
        }
    }
}
