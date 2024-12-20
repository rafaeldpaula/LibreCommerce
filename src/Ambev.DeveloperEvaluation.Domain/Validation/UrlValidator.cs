using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class UrlValidator : AbstractValidator<string>
{
    public UrlValidator()
    {
        RuleFor(url => url)
            .NotEmpty()
            .WithMessage("Url cannot be empty.")
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("Url must be a valid URL.");
    }
}