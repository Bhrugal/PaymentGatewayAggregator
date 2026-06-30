using PaymentGatewayAggregator.Domain.Entities;

namespace PaymentGatewayAggregator.Application.Interfaces.Repositories;

public interface IPaymentRepository
{
    Task<List<Payment>> GetAllAsync();

    Task<Payment?> GetByIdAsync(Guid id);

    Task AddAsync(Payment payment);

    Task UpdateAsync(Payment payment);

    Task DeleteAsync(Payment payment);
}