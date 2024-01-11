// Copyright (c) 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace License
// you may not use this file except in compliance with the License.
// Change License: Reciprocal Public License 1.5
//     https://mariadb.com/bsl11
//     https://opensource.org/license/rpl-1-5
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created At: Sunday, 31st Dec 2023
// Modified By: Godwin peter .O
// Modified At: Thu Jan 04 2024

using Trace.Application.Core;
using Trace.Service.Navigation;
using Trace.ServiceDefaults;
using Trace.ServiceDefaults.Extensions;
using Trace.Infrastructure.Cassandra;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(TenantEntity<>).Assembly;

builder.RegisterDefaults();
builder.RegisterPersistence(assembly);
builder.Services.RegisterCassandraInfrastructure();
builder.Services.RegisterDefaultServices();
builder.Services.RegisterHangfire(Nodes.Navigation);
builder.Services.AddGraphQLServer()
    .AddGraphqlDefaults(Nodes.Navigation)
    .AddQueryType<Query>()
    .AddQueryableCursorPagingProvider()
    .RegisterObjectExtensions(typeof(Program).Assembly);

var app = builder.Build();

app.RegisterDefaults();
app.UseHangfireDashboard(Nodes.Navigation);
app.RegisterGraphQl();

app.Run();