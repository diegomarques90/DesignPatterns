using DesignPatterns.Infrastructure.Integrations;
using DesignPatterns.Infrastructure.Payments;
using DesignPatterns.Infrastructure.Payments.Interfaces;
using DesignPatterns.Infrastructure.Products;
using DesignPatterns.Infrastructure.Proxies;
using DesignPatterns.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IPaymentServiceFactory, PaymentServiceFactory>();
builder.Services.AddTransient<CreditCardService>();
builder.Services.AddTransient<PaymentSlipService>();
builder.Services.AddTransient<IExternalPaymentSlipService, ExternalPaymentSlipService>();
builder.Services.AddTransient<ICoreCrmIntegrationService, CoreCrmIntegrationService>();
builder.Services.AddTransient<IProductRepository, ProductyRepository>();
builder.Services.AddTransient<IPaymentFraudCheckService, PaymentFraudCheckService>();
builder.Services.AddScoped<CustomerRepositoryProxy>();
builder.Services.AddSingleton<PaymentMethodsFactory>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
