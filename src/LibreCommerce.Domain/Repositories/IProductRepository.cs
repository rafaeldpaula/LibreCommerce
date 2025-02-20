﻿using LibreCommerce.Domain.Entities;

namespace LibreCommerce.Domain.Repositories;

public interface IProductRepository
{
    /// <summary>
    /// Retrieves a product by their unique id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Product?> GetProductByIdAsync(int id);
    
    /// <summary>
    /// Retrieves all products
    /// </summary>
    /// <returns></returns>
    Task<List<Product>?> GetProductsAsync();
}