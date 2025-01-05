using LibreCommerce.Domain.Entities;
using LibreCommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibreCommerce.ORM.Repositories;

public class ProductRepository(DefaultContext _context) : IProductRepository
{
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task<List<Product>?> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
}