//using PaymentGatewayAggregator.Persistence.DependencyInjection;
//using PaymentGatewayAggregator.Application.DependencyInjection;
//using PaymentGatewayAggregator.Persistence;


//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddPersistence(builder.Configuration);


//builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.MapControllers();

//app.Run();

using Serilog;
using PaymentGatewayAggregator.API.Middleware;
using PaymentGatewayAggregator.Application.DependencyInjection;
using PaymentGatewayAggregator.Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

 builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddApplication();      // <-- Missing
builder.Services.AddPersistence(builder.Configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();