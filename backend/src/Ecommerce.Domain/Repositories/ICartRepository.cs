using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories;

public interface ICartRepository
{
    Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<List<Cart>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Cart cart, CancellationToken cancellationToken = default);
    Task<bool> DeleteByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}
