using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductCommandValidator : AbstractValidator<Product>
{
    public ProductCommandValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty()
            .WithMessage("Title cannot be empty.");
        
        RuleFor(product => product.Price)
            .NotEmpty()
            .WithMessage("Price cannot be empty.");
        
        RuleFor(product => product.Category)
            .NotEmpty()
            .WithMessage("Category cannot be empty.");
        
        RuleFor(product => product.Image)
            .SetValidator(new UrlValidator());
        
        RuleFor(product => product.Rate)
            .NotEmpty()
            .WithMessage("Rate cannot be empty.");
        
        RuleFor(product => product.Count)
            .NotEmpty()
            .WithMessage("Count cannot be empty.");
    }
}