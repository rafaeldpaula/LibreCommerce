using LibreCommerce.Domain.Enums;
using LibreCommerce.Domain.Validation;
using LibreCommerce.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace LibreCommerce.Unit.Domain.Validation;

public class GetProductCommandValidatorTests
{
    readonly ProductCommandValidator _productCommandValidator;

    public GetProductCommandValidatorTests()
    {
        _productCommandValidator = new ProductCommandValidator();
    }

    [Fact(DisplayName = "Should return true if product is valid")]
    public void Create_ValidProduct_Then_ShouldNotReturnErrorsMessages()
    {
        var product = ProductTestData.GenerateValidProduct();

        var result = _productCommandValidator.TestValidate(product);

        result.ShouldNotHaveValidationErrorFor(x => x.ProductId);
    }
}