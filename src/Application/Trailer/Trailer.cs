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
// Created At: Wednesday, 3rd Jan 2024
// Modified By: Godwin peter .O
// Modified At: Wed Jan 03 2024

using Trace.Application.Asset;
using Trace.Application.Core.Enums;

namespace Trace.Application.Trailer;

public sealed class Trailer : AssetEntity {
    public TrailerType Type { get; set; }

    public string FleetIdentifier { get; set; } = String.Empty;

    public long Odometer { get; set; }

    public int HorsePower { get; set; }

    public string Model { get; set; } = null!;

    public decimal WeightCapacity { get; set; }

    public decimal AxleWeightCapacity { get; set; }
}