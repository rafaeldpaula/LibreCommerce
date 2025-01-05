using LibreCommerce.Domain.Entities;
using LibreCommerce.Domain.Enums;

namespace LibreCommerce.Domain.Specifications;

public class ActiveUserSpecification : ISpecification<User>
{
    public bool IsSatisfiedBy(User user)
    {
        return user.Status == UserStatus.Active;
    }
}
