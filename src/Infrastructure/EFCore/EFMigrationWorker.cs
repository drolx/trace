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
// Created At: Saturday, 13th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Thu Jan 18 2024

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trace.Application;
using Trace.Application.Device;
using Trace.Application.Engagement;
using Trace.Application.Tags;
using Trace.Application.Tenant;
using Trace.Application.Vehicle;
using Trace.Application.Core.Enums;
using NetTopologySuite.Geometries;
using Location = Trace.Application.Location.Location;
using Trace.Application.Engagement.Enums;

namespace Trace.Infrastructure.EFCore;

public class EfMigrationWorker(ILogger<EfMigrationWorker> logger, IServiceScopeFactory factory) : BackgroundService {
    private readonly ServiceContext _context = factory.CreateScope().ServiceProvider.GetRequiredService<ServiceContext>();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        logger.LogInformation("Starting migration...");
        await _context.Database.MigrateAsync(stoppingToken);
        logger.LogInformation("Completed migration...");

        logger.LogInformation("Started seeding data...");

        var dataSeeded = await _context.Set<Tenant>().AnyAsync(stoppingToken);
        var tenantId = Guid.NewGuid();
        if (!dataSeeded) {
            // Seed Tenants
            await _context.Set<Tenant>().AddAsync(new Tenant {
                Id = tenantId,
                Active = true,
                Name = "Local Corp",
                Domains = [new TenantDomains { Domain = "localhost" }],
                Contact = new Contact {
                    FullName = "Local Corporation",
                    Type = ContactVariant.Organization,
                    Email = "contact@local-corp.com",
                    Addresses = [
                        new Address { Line1 = "001 X Street", City = "Gos" }]
                }
            }, stoppingToken);

            // Seed Tags
            await _context.Set<Tags>().AddAsync(new Tags {
                Name = "Tag-00",
            }, stoppingToken);

            // Seed Contact
            await _context.Set<Contact>().AddAsync(new Contact {
                TenantId = tenantId,
                Email = "john.doe@email.com",
                FullName = "John Doe",
                Addresses = [
                    new Address() { Line1 = "Aurora avenue 1", City = "LA", Country = "USA" }
                ]
            }, stoppingToken);

            // Seed Vehicles
            await _context.Set<Vehicle>().AddAsync(new Vehicle {
                TenantId = tenantId,
                RegistrationNo = "XX 123 XXX",
                FleetIdentifier = "fleet-001",
                // Seed Device
                Device = new Device {
                    UniqueId = "123456",
                    Phone = "+2345678901234"
                }
            }, stoppingToken);

            // Seed Location
            await _context.Set<Location>().AddAsync(new Location {
                Name = "Test-00",
                Address = "Test",
                Default = true,
                Type = LocationType.Custom,
                Geometry = new Point(6.243, 3.3431),
                Description = "A sample location"
            }, stoppingToken);

            await _context.SaveChangesAsync(stoppingToken);
            logger.LogInformation("Completed seeding data...");
        }
    }
}