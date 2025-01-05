using LibreCommerce.Application.Users.CreateUser;
using LibreCommerce.Common.Validation;
using MediatR;

namespace LibreCommerce.Application.Products.GetUser;

public class GetProductCommand : IRequest<GetProductCommandResult>
{
    public int Id { get; set; }
    
    public ValidationResultDetail Validate()
    {
        var validator = new GetProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}