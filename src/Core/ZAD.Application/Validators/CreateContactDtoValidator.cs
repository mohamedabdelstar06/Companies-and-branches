using FluentValidation;
using ZAD.Application.DTOs.Common;
using ZAD.Application.Strategies.ContactValidation;

namespace ZAD.Application.Validators
{
    public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactDtoValidator()
        {
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x).Must(x => 
            {
                var strategy = ContactValidationStrategyFactory.GetStrategy(x.Type);
                return strategy.IsValid(x.Value);
            }).WithMessage("Invalid contact value for the selected contact type.");
        }
    }
}

