using Microsoft.EntityFrameworkCore;
using MassTransit;
using ServiceRequisicaoCEP;
using ServiceRequisicaoCEP.DependencyInjection;
using ServiceRequisicaoCEP.Eventos;
using ServiceRequisicaoCEP.Mappings;
using ServiceRequisicaoCEP.Context;
using CoreRequisicaoCEP;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(cfg =>
    {
        cfg.Build();
        cfg.AddAzureAppConfiguration("Endpoint=https://cf-equisicaocep.azconfig.io;Id=qRYY;Secret=F88MXH3X/plMSk1P2dfho/17XXdC6hf+pgSj95r+36g=");
    })
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        services.AddHostedService<Worker>();

        // SQL
        var sqlServerConnection = Connection.GetServiceSQLServerConnection();
        //var sqlServerConnection = configuration.GetSection("ConnectionStrings")["AZURE_SQL_CONNECTIONSTRING"] ?? string.Empty;

        services.AddDbContext<RequisicaoCEPContext>(options =>
            options.UseSqlServer(sqlServerConnection));

        // Service Bus
        //var serviceBusConnection = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;
        var serviceBusConnection = Connection.GetServiceBusConnection();
        //var nomeFila = configuration.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;
        var nomeFila = configuration["kv-filarequisicaocep"] ?? string.Empty;

        services.AddMassTransit(x =>
        {
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(serviceBusConnection);
                cfg.ReceiveEndpoint(nomeFila, endpoint =>
                {
                    endpoint.ConfigureConsumer<RequisicaoCEPConsumidor>(context);
                });
            });

            x.AddConsumer<RequisicaoCEPConsumidor>();
        });

        ConfigureRepository.ConfigureDependenciesRepository(services);

        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new ModelToEntityProfile());
        }, AppDomain.CurrentDomain.GetAssemblies());
    })
    .Build();

host.Run();
