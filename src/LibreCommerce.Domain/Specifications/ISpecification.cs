﻿namespace LibreCommerce.Domain.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);
}
