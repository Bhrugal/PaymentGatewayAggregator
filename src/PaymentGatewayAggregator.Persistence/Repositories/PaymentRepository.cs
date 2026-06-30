using Microsoft.EntityFrameworkCore;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;
using PaymentGatewayAggregator.Domain.Entities;
using PaymentGatewayAggregator.Persistence.Context;

namespace PaymentGatewayAggregator.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Payment>> GetAllAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task<Payment?> GetByIdAsync(Guid id)
    {
        return await _context.Payments.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Payment payment)
    {
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }
}