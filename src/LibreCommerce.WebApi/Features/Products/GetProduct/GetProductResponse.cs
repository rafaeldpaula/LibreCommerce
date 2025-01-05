namespace LibreCommerce.WebApi.Features.Products.GetProduct;

public class GetProductResponse
{
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? Image { get; set; }
    public RatingData Rating { get; set; }

    public class RatingData
    {
        public Decimal Rate { get; set; }
        public int Count { get; set; }
    }
}