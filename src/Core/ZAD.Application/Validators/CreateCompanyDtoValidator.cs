using FluentValidation;
using ZAD.Application.DTOs.Company;

namespace ZAD.Application.Validators
{
    public class CreateCompanyDtoValidator : AbstractValidator<CreateCompanyDto>
    {
        public CreateCompanyDtoValidator()
        {
            RuleFor(x => x.NameAr).NotEmpty();
            RuleFor(x => x.NameEn).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));
            RuleFor(x => x.Logo).Must(x => x == null || x.ContentType.StartsWith("image/")).WithMessage("Logo must be an image.");
        }
    }
}
