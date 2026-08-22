using FluentValidation;
using ZAD.Application.DTOs.VehicleRental.Tenant;
using System;

namespace ZAD.Application.Validators.VehicleRental
{
    public class CreateTenantDtoValidator : AbstractValidator<CreateTenantDto>
    {
        public CreateTenantDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Birthday).NotEmpty().Must(BeValidAge).WithMessage("Tenant age must be between 18 and 60 years old.");
        }

        private bool BeValidAge(DateTime birthday)
        {
            var age = Math.Max(0, (DateTime.Today - birthday).Days / 365);
            return age >= 18 && age <= 60;
        }
    }
}
