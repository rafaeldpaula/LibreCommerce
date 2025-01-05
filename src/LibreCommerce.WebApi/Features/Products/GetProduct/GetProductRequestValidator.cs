using FluentValidation;

namespace LibreCommerce.WebApi.Features.Products.GetProduct;

public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
{
    public GetProductRequestValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}