using HotChocolate;
using HotChocolate.Types;
using Trace.Common.Infrastructure.Extensions;
using Trace.Common.Service;
using Trace.Common.Service.Extensions;
using Trace.Service.Stream;

var builder = WebApplication.CreateBuilder(args).RegisterSharedArchitecture();

builder.Services
.AddAuthorization()
.RegisterHangfire(Nodes.Stream)
.RegisterSharedDataConnector(builder.Configuration);

builder.Services
.AddMemoryCache()
.AddGraphQLServer()
.AddGraphqlDefaults(Nodes.Stream)
.AddType<UploadType>()
.AddQueryType<Query>()
.AddSpatialTypes()
.AddSpatialFiltering()
.AddSpatialProjections()
.AddQueryableCursorPagingProvider()
.RegisterObjectExtensions(typeof(Program).Assembly);

var app = builder.Build();
app.MapGet("/", () => "Service.Stream");
app.UseSharedEndpoint();
app.UseHangfireDashboard(builder.Configuration, Nodes.Stream);

app.Run();