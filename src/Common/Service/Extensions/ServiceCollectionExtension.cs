using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Steeltoe.Bootstrap.Autoconfig;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Connector.Redis;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;
using Steeltoe.Extensions.Configuration.ConfigServer;
using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;
using Steeltoe.Messaging.RabbitMQ.Config;
using Steeltoe.Messaging.RabbitMQ.Extensions;

namespace Trace.Common.Service.Extensions;

public static class ServiceCollectionExtension {

    public static IServiceCollection RegisterRedis(this IServiceCollection services, IConfiguration config) {
        var redisConnectionString = config.GetValue<string>("redis") ?? "localhost";
        return services.AddSingleton(sp => {
            ArgumentNullException.ThrowIfNull(redisConnectionString);
            return ConnectionMultiplexer.Connect(redisConnectionString);
        });
    }

    public static IServiceCollection RegisterSchemaHttpClients(this IServiceCollection services,
        IDictionary<string, Uri> schemas) {
        foreach (var schema in schemas) {
            services.AddTransient<DiscoveryHttpMessageHandler>();
            services.AddHttpClient(schema.Key, c => {
                ArgumentNullException.ThrowIfNull(schema.Value, "GraphqlEndpoint");
                c.BaseAddress = new Uri(schema.Value, "/graphql");
            })
            .AddHttpMessageHandler<DiscoveryHttpMessageHandler>();
        }

        return services;
    }

    public static IServiceCollection RegisterDistributedCache(this IServiceCollection services, IConfiguration config) {
        var sp = services.BuildServiceProvider();
        services.AddDataProtection()
        .SetApplicationName(Nodes.GroupName)
        .PersistKeysToStackExchangeRedis(sp.GetRequiredService<ConnectionMultiplexer>(), "DataProtection-Keys");

        services.AddStackExchangeRedisCache(options => {
            options.Configuration = config.GetValue<string>("redis") ?? "localhost";
            options.InstanceName = "";
        });

        services.AddSession(o => {
            o.Cookie.Name = Nodes.GroupName;
            o.Cookie.SameSite = SameSiteMode.None;
            o.IdleTimeout = TimeSpan.FromMinutes(10);
            // o.Cookie.HttpOnly = true;
        });

        return services;
    }

    public static WebApplicationBuilder RegisterSharedArchitecture(this WebApplicationBuilder builder) {
        var env = builder.Environment;
        builder.Configuration.SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
        .AddConfigServer()
        .AddEnvironmentVariables();
        
        builder.AddSteeltoe();
        builder.Services.AddDiscoveryClient(builder.Configuration);
        builder.Services.AddServiceDiscovery(o => o.UseConsul());
        builder.Services.AddDistributedTracingAspNetCore();
        builder.Services.AddDistributedRedisCache(builder.Configuration);
        builder.Services.AddAllActuators();
        builder.Services.AddRabbitServices();
        builder.Services.AddRabbitAdmin();
        builder.Services.AddRabbitTemplate();
        builder.Services.AddRabbitQueue(new Queue("default"));

        return builder;
    }
}