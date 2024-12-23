using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public int ProductId { get; set; }
    public string? Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? Category { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public int Count { get; set; }
    public ProductStatus Status { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new ProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    public void Deactivate()
    {
        UpdatedAt = DateTime.UtcNow;
        Status = ProductStatus.Inactive;
    }

    public void Activate()
    {
        UpdatedAt = DateTime.UtcNow;
        Status = ProductStatus.Active;
    }
}