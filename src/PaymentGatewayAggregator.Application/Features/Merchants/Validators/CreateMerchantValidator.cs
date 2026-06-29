using FluentValidation;
using PaymentGatewayAggregator.Application.Features.Merchants.Commands;

namespace PaymentGatewayAggregator.Application.Features.Merchants.Validators;

public class CreateMerchantValidator : AbstractValidator<CreateMerchantCommand>
{
    public CreateMerchantValidator()
    {
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