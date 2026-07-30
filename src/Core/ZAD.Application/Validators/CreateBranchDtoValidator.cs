using FluentValidation;
using ZAD.Application.DTOs.Branch;

namespace ZAD.Application.Validators
{
    public class CreateBranchDtoValidator : AbstractValidator<CreateBranchDto>
    {
        public CreateBranchDtoValidator()
        {
            RuleFor(x => x.NameAr).NotEmpty();
            RuleFor(x => x.NameEn).NotEmpty();
            RuleFor(x => x.CompanyId).GreaterThan(0);
            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));
            RuleFor(x => x.Logo).Must(x => x == null || x.ContentType.StartsWith("image/")).WithMessage("Logo must be an image.");
        }
    }
}
