using MassTransit;
using CoreRequisicaoCEP;
using APIRequisicaoCEP.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsTelemetry();

builder.Host.ConfigureAppConfiguration(cfg =>
{
    cfg.Build();
    cfg.AddAzureAppConfiguration("Endpoint=https://cf-equisicaocep.azconfig.io;Id=qRYY;Secret=F88MXH3X/plMSk1P2dfho/17XXdC6hf+pgSj95r+36g=");
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var configuration = builder.Configuration;
//var conexao = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;
var serviceBusConnection = Connection.GetServiceBusConnection();

builder.Services.AddMassTransit(x =>
{
    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host(serviceBusConnection);
    });
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new DtoToModelProfile());
}, AppDomain.CurrentDomain.GetAssemblies());

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
