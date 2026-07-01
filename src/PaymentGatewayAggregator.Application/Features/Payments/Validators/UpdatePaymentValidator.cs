using FluentValidation;
using PaymentGatewayAggregator.Application.Features.Payments.Commands;

namespace PaymentGatewayAggregator.Application.Features.Payments.Validators;

public class UpdatePaymentValidator : AbstractValidator<UpdatePaymentCommand>
{
    public UpdatePaymentValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.Currency)
            .NotEmpty();

        RuleFor(x => x.Status)
            .NotEmpty();
    }
}