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
// Created At: Thursday, 4th Jan 2024
// Modified By: Godwin peter .O
// Modified At: Thu Jan 04 2024

using MassTransit.Mediator;
using Microsoft.Extensions.Logging;
using Trace.Application.Device.Contracts;

namespace Trace.Application.Device.Handlers;

public class DevicePositionHandler(ILogger<DevicePositionHandler> logger) : MediatorRequestHandler<CreateDevicePosition, DevicePositionResponse> {
    protected override Task<DevicePositionResponse> Handle(CreateDevicePosition request, CancellationToken cancellationToken) {
        logger.LogInformation($"Received position for device : {request.Payload?.Id}");

        return Task.FromResult(new DevicePositionResponse { Id = Guid.NewGuid(), Status = "Created" });
    }
}