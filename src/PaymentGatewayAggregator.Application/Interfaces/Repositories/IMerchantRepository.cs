using PaymentGatewayAggregator.Domain.Entities;

namespace PaymentGatewayAggregator.Application.Interfaces.Repositories;

public interface IMerchantRepository
{
    Task<List<Merchant>> GetAllAsync();

    Task<Merchant?> GetByIdAsync(Guid id);

    Task AddAsync(Merchant merchant);

    Task UpdateAsync(Merchant merchant);

    Task DeleteAsync(Merchant merchant);
}