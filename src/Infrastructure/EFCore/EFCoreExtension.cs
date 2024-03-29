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
// Created At: Thursday, 11th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Fri Jan 12 2024

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trace.Application;

namespace Trace.Infrastructure.EFCore;

public static class EfCoreExtension {
    public static WebApplicationBuilder RegisterEfCoreInfrastructure(this WebApplicationBuilder builder) {
        var connectionString = builder.Configuration.GetConnectionString("db");

        builder.AddNpgsqlDbContext<ServiceContext>("db",
        configureSettings => {
            configureSettings.HealthChecks = true;
            configureSettings.ConnectionString = connectionString;
        },
        DbOptions);
        builder.Services.AddPooledDbContextFactory<ServiceContext>(DbOptions);

        return builder;

        void DbOptions(DbContextOptionsBuilder options) {
            options.UseSnakeCaseNamingConvention();
            options.UseNpgsql(connectionString, b => b
                .MigrationsAssembly(typeof(ServiceContextFactory).Assembly.FullName)
                .EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null)
                .UseNetTopologySuite());
        }
    }
}