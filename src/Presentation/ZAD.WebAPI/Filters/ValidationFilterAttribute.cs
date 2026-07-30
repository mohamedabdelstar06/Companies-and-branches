using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace ZAD.WebAPI.Filters
{
    public class ValidationFilterAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var argument in context.ActionArguments.Values.Where(v => v != null))
            {
                var validatorType = typeof(IValidator<>).MakeGenericType(argument!.GetType());
                var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

                if (validator != null)
                {
                    var validationContextType = typeof(ValidationContext<>).MakeGenericType(argument.GetType());
                    var validationContext = Activator.CreateInstance(validationContextType, new object[] { argument }) as IValidationContext;
                    
                    if (validationContext != null)
                    {
                        var result = await validator.ValidateAsync(validationContext);
                        if (!result.IsValid)
                        {
                            throw new ValidationException(result.Errors);
                        }
                    }
                }
            }

            await next();
        }
    }
}
