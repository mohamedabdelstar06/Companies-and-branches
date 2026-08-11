using FluentValidation;
using ZAD.Application.DTOs.Branch;

namespace ZAD.Application.Validators
{
    public class UpdateBranchDtoValidator : AbstractValidator<UpdateBranchDto>
    {
        public UpdateBranchDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.NameAr).NotEmpty();
            RuleFor(x => x.NameEn).NotEmpty();
            RuleFor(x => x.CompanyId).GreaterThan(0);
            RuleForEach(x => x.Contacts).SetValidator(new CreateContactDtoValidator()).When(x => x.Contacts != null);
            RuleForEach(x => x.Documents).SetValidator(new CreateDocumentDtoValidator()).When(x => x.Documents != null);
        }
    }
}
