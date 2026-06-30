using FluentValidation;
using PaymentGatewayAggregator.Application.Features.Payments.Commands;

namespace PaymentGatewayAggregator.Application.Features.Payments.Validators;

public class CreatePaymentValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentValidator()
    {
        RuleFor(x => x.MerchantId)
            .NotEmpty();

        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.Currency)
            .NotEmpty()
            .MaximumLength(10);
    }
}