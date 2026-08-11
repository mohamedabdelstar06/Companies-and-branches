using FluentValidation;
using ZAD.Application.DTOs.Common;

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
                var strategy = Strategies.ContactValidationStrategyFactory.GetStrategy(x.Type);
                return strategy.IsValid(x.Value);
            }).WithMessage("Invalid contact value for the selected contact type.");
        }
    }
}
