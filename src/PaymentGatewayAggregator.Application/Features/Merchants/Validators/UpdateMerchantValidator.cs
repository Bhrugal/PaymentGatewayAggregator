using FluentValidation;
using PaymentGatewayAggregator.Application.Features.Merchants.Commands;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Validators;

public class UpdateMerchantValidator : AbstractValidator<UpdateMerchantCommand>
{
    public UpdateMerchantValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.GatewayType)
            .NotEmpty();
    }
}