using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class ProductTest
{
    [Fact(DisplayName = "ProductID must be valid to return the correct products values")]
    public void Given_ValidProductId_Then_Return_Valid_Product_Values()
    {
        var product = ProductTestData.GenerateValidProduct();

        product.ProductId = 1;
        
        Assert.Equal(1, product.ProductId);
    }
}