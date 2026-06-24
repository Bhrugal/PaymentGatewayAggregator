using PaymentGatewayAggregator.Domain.Entities;

namespace PaymentGatewayAggregator.Application.Interfaces;

public interface IMerchantRepository
{
    Task<Merchant?> GetByIdAsync(Guid id);

    Task<List<Merchant>> GetAllAsync();

    Task AddAsync(Merchant merchant);
}