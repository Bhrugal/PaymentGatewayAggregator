//using FluentValidation;
//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using System.Reflection;

//namespace PaymentGatewayAggregator.Application.DependencyInjection;

//public static class ServiceCollectionExtensions
//{
//    public static IServiceCollection AddApplication(this IServiceCollection services)
//    {
//        var assembly = Assembly.GetExecutingAssembly();

//        services.AddMediatR(cfg =>
//        {
//            cfg.RegisterServicesFromAssembly(assembly);
//        });

//        services.AddValidatorsFromAssembly(assembly);

//        return services;
//    }
//}



using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PaymentGatewayAggregator.Application.Behaviors;

namespace PaymentGatewayAggregator.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
        });

        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        return services;
    }
}