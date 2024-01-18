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

using Axolotl.EFCore.Base;
using Axolotl.EFCore.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trace.Application.Account;
using Trace.Application.Core.Interfaces;
using Trace.Application.Engagement;
using Trace.Application.Tenant;

namespace Trace.Application;

public partial class ServiceContext : IdentityDbContext<UserAccount, UserRole, Guid> {
    private Guid? TenantId { get; set; }
    public ServiceContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        var assembly = typeof(ITenantEntity).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        modelBuilder.RegisterAllEntities<CoreEntity>(assembly);
        modelBuilder.RegisterSoftDeleteFilter();
        // TODO: Add condition to exclude manager service
        // RegisterTenantFilter(modelBuilder);
    }
    public DbSet<Tenant.Tenant> Tenants { get; set; } = default!;
    public DbSet<TenantDomains> TenantDomains { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Vehicle.Vehicle> Vehicles { get; set; }
    public DbSet<Trailer.Trailer> Trailers { get; set; }
    public DbSet<Asset.Asset> Assets { get; set; }
    public DbSet<Device.Device> Devices { get; set; }
    public DbSet<Location.Location> Locations { get; set; }
    public DbSet<Routes.Routes> Routes { get; set; }
}