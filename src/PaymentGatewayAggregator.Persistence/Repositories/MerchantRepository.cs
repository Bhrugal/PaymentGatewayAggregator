using Microsoft.EntityFrameworkCore;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;
using PaymentGatewayAggregator.Domain.Entities;
using PaymentGatewayAggregator.Persistence.Context;

namespace PaymentGatewayAggregator.Persistence.Repositories;

public class MerchantRepository : IMerchantRepository
{
    private readonly ApplicationDbContext _context;

    public MerchantRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Merchant>> GetAllAsync()
    {
        return await _context.Merchants.ToListAsync();
    }

    public async Task<Merchant?> GetByIdAsync(Guid id)
    {
        return await _context.Merchants.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Merchant merchant)
    {
        await _context.Merchants.AddAsync(merchant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Merchant merchant)
    {
        _context.Merchants.Update(merchant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Merchant merchant)
    {
        _context.Merchants.Remove(merchant);
        await _context.SaveChangesAsync();
    }
}