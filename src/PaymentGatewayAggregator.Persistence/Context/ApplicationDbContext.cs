using Microsoft.EntityFrameworkCore;
using PaymentGatewayAggregator.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using PaymentGatewayAggregator.Domain.Entities;

namespace PaymentGatewayAggregator.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Merchant> Merchants => Set<Merchant>();

    public DbSet<Payment> Payments => Set<Payment>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}