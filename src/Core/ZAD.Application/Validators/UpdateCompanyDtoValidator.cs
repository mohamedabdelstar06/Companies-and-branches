using FluentValidation;
using ZAD.Application.DTOs.Company;

namespace ZAD.Application.Validators
{
    public class UpdateCompanyDtoValidator : AbstractValidator<UpdateCompanyDto>
    {
        public UpdateCompanyDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.NameAr).NotEmpty();
            RuleFor(x => x.NameEn).NotEmpty();
            RuleForEach(x => x.Contacts).SetValidator(new CreateContactDtoValidator()).When(x => x.Contacts != null);
            RuleForEach(x => x.Documents).SetValidator(new CreateDocumentDtoValidator()).When(x => x.Documents != null);
        }
    }
}
