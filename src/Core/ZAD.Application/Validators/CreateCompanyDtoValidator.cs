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
            RuleForEach(x => x.Contacts).SetValidator(new CreateContactDtoValidator()).When(x => x.Contacts != null);
            RuleForEach(x => x.Documents).SetValidator(new CreateDocumentDtoValidator()).When(x => x.Documents != null);
        }
    }
}
