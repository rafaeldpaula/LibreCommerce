using LibreCommerce.Domain.Entities;
using LibreCommerce.Domain.Enums;
using Bogus;

namespace LibreCommerce.Unit.Domain.Entities.TestData;

public static class ProductTestData
{
    private static Faker<Product> productFaker = new Faker<Product>()
        .RuleFor(p => p.ProductId, f => f.IndexFaker)
        .RuleFor(p => p.Title, f => f.Commerce.ProductName())
        .RuleFor(p => p.Price, f => Convert.ToDecimal(f.Commerce.Price(f.Random.Decimal(10))))
        .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
        .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
        .RuleFor(p => p.Image, f => f.Internet.Url())
        .RuleFor(p => p.Rate, f => f.Random.Decimal(10))
        .RuleFor(p => p.Count, f => f.Random.Number(1, 100))
        .RuleFor(p => p.Status, f => f.PickRandom(ProductStatus.Active, ProductStatus.Inactive))
        .RuleFor(p => p.CreatedAt, f => f.Date.Past())
        .RuleFor(p => p.UpdatedAt, f => f.Date.Past());

    public static Product GenerateValidProduct()
    {
        return productFaker.Generate();
    }

    public static List<Product> GenerateProducts()
    {
        return productFaker.Generate(5);
    }

    public static string GenerateValidImageUrl()
    {
        return new Faker().Internet.Url();
    }

    public static string GenerateInvalidImageUrl()
    {
        return new Faker().Lorem.Word();
    }
}