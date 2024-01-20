﻿// Copyright (c) 2023 - 2024 drolx Solutions
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
// Modified At: Thu Jan 11 2024

using Microsoft.AspNetCore.Http;
using Redis.OM;
using Redis.OM.Searching;
using Trace.Application.Tenant;

namespace Trace.Infrastructure.Providers;

public interface ITenantProvider {
    public string GetDomain();
    public Guid? GetTenantId();
}

public class TenantProvider(RedisConnectionProvider provider, IHttpContextAccessor httpContext) : ITenantProvider {
    private readonly IRedisCollection<TenantDomains> _domains = provider.RedisCollection<TenantDomains>();

    public string GetDomain() => httpContext.HttpContext!.Request.Host.Host;

    public Guid? GetTenantId() {
        var domain = _domains.Single(x => x.Domain == GetDomain());

        return domain.TenantId;
    }
}
