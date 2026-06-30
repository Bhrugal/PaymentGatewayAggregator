using MediatR;
using PaymentGatewayAggregator.Application.Features.Merchants.Commands;
using PaymentGatewayAggregator.Application.Interfaces.Repositories;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Handlers;

public class DeleteMerchantHandler
    : IRequestHandler<DeleteMerchantCommand, bool>
{
    private readonly IMerchantRepository _repository;

    public DeleteMerchantHandler(IMerchantRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteMerchantCommand request,
        CancellationToken cancellationToken)
    {
        var merchant = await _repository.GetByIdAsync(request.Id);

        if (merchant == null)
            return false;

        await _repository.DeleteAsync(merchant);

        return true;
    }
}