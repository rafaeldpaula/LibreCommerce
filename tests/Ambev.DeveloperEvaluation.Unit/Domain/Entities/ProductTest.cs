using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class ProductTest
{
    [Fact(DisplayName = "Verify if a product is active")]
    public void Given_AnyProduct_Then_Verify_Product_IsActivated()
    {
        var product = ProductTestData.GenerateValidProduct();

        product.Activate();

        Assert.Equal(ProductStatus.Active, product.Status);
    }

    [Fact(DisplayName = "Verify if a product is inactive")]
    public void Given_AnyProduct_Then_Verify_Product_IsNotActivated()
    {
        var product = ProductTestData.GenerateValidProduct();

        product.Deactivate();

        Assert.Equal(ProductStatus.Inactive, product.Status);
    }

    [Fact(DisplayName = "Verify if a product is created correctly")]
    public void Given_InvalidProductData_Then_ShouldReturnInvalid()
    {
        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Title = "",
            Description = "",
            Price = 0,
            Status = ProductStatus.Unknown,
            Category = "",
            Image = ProductTestData.GenerateInvalidImageUrl(),
            Count = 0,
            Rate = 0
        };

        var result = product.Validate();

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}