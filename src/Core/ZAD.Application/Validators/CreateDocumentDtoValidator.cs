using FluentValidation;
using ZAD.Application.DTOs.Common;

namespace ZAD.Application.Validators
{
    public class CreateDocumentDtoValidator : AbstractValidator<CreateDocumentDto>
    {
        public CreateDocumentDtoValidator()
        {
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.DocumentNumber).NotEmpty();
            RuleFor(x => x.AttachFile).Must(x => x == null || (x.ContentType.StartsWith("image/") || x.ContentType == "application/pdf"))
                .WithMessage("Document must be an image or PDF.");
        }
    }
}
