using LibreCommerce.Application.Users.CreateUser;
using FluentValidation;


namespace LibreCommerce.Application.Products.GetUser;

public class GetProductCommandValidator : AbstractValidator<GetProductCommand>
{
    public GetProductCommandValidator()
    {
        RuleFor(product => product.Id)
            .Must(id => int.TryParse(id.ToString(), out _))
            .WithMessage("Id must be a valid integer.");
    }
}