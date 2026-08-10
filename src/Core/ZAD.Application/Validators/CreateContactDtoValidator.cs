using FluentValidation;
using ZAD.Application.DTOs.Common;

namespace ZAD.Application.Validators
{
    public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactDtoValidator()
        {
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
