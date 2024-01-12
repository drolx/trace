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

using NetTopologySuite.Geometries;
using Redis.OM.Modeling;
using Trace.Application.Abstractions;
using Trace.Application.Core.Enums;

namespace Trace.Application.Location;

[Document(StorageType = StorageType.Hash, Prefixes = [nameof(Location)])]
public class Location : TaggedEntity<Guid> {
    [Indexed]
    public bool Default { get; set; }
    [Indexed]
    public required string Name { get; set; }
    [Indexed]
    public string? Address { get; set; }
    public DateTimeOffset? ApprovedAt { get; set; }
    public string? ApprovedBy { get; set; }
    [Indexed]
    public LocationType? Type { get; set; }
    [Indexed(CascadeDepth = 1)]
    public LocationCategory? Category { get; set; }
    [Indexed]
    public Guid? CategoryId { get; set; }
    [Indexed]
    public double? Longitude { get; set; }
    [Indexed]
    public double? Latitude { get; set; }
    [Indexed(CascadeDepth = 1)]
    public Geometry Geometry { get; set; } = null!;
    [Indexed]
    public string? Description { get; set; }
}