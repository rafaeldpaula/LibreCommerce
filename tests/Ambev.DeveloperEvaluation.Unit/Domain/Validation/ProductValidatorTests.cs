using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class ProductValidatorTests
{
    readonly ProductValidator _productValidator;

    public ProductValidatorTests()
    {
        _productValidator = new ProductValidator();
    }

    [Fact(DisplayName = "Should return true if product is valid")]
    public void Create_ValidProduct_Then_ShouldNotReturnErrorsMessages()
    {
        var product = ProductTestData.GenerateValidProduct();

        var result = _productValidator.TestValidate(product);

        result.ShouldNotHaveValidationErrorFor(x => x.ProductId);
    }
}