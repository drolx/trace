﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Trace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "account_map_option",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    map_type = table.Column<string>(type: "text", nullable: true),
                    zoom = table.Column<int>(type: "integer", nullable: true),
                    zoom_selection = table.Column<int>(type: "integer", nullable: true),
                    enable_trip = table.Column<bool>(type: "boolean", nullable: false),
                    auto_route = table.Column<bool>(type: "boolean", nullable: false),
                    auto_order = table.Column<bool>(type: "boolean", nullable: false),
                    auto_route_cost = table.Column<bool>(type: "boolean", nullable: false),
                    auto_invoice = table.Column<bool>(type: "boolean", nullable: false),
                    verify_otp = table.Column<bool>(type: "boolean", nullable: false),
                    auto_zone_otp = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_map_option", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "account_notification",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    types = table.Column<int[]>(type: "integer[]", nullable: false),
                    schedule = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_notification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "account_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    token = table.Column<string>(type: "text", nullable: true),
                    language = table.Column<string>(type: "text", nullable: true),
                    timezone = table.Column<string>(type: "text", nullable: true),
                    hour24time = table.Column<bool>(type: "boolean", nullable: false),
                    unit_distance = table.Column<string>(type: "text", nullable: true),
                    unit_volume = table.Column<string>(type: "text", nullable: true),
                    unit_weight = table.Column<string>(type: "text", nullable: true),
                    unit_temperature = table.Column<string>(type: "text", nullable: true),
                    unit_speed = table.Column<string>(type: "text", nullable: true),
                    unit_power = table.Column<string>(type: "text", nullable: true),
                    unit_pressure = table.Column<string>(type: "text", nullable: true),
                    unit_force = table.Column<string>(type: "text", nullable: true),
                    unit_area = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    root = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asset_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asset_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contact_object",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    number_of_children = table.Column<int>(type: "integer", nullable: false),
                    next_kin_name = table.Column<string>(type: "text", nullable: true),
                    next_kin_phone = table.Column<string>(type: "text", nullable: true),
                    next_kin_email = table.Column<string>(type: "text", nullable: true),
                    guarantor_name = table.Column<string>(type: "text", nullable: true),
                    guarantor_phone = table.Column<string>(type: "text", nullable: true),
                    guarantor_email = table.Column<string>(type: "text", nullable: true),
                    address_line1 = table.Column<string>(type: "text", nullable: true),
                    address_line2 = table.Column<string>(type: "text", nullable: true),
                    address_city = table.Column<string>(type: "text", nullable: true),
                    address_county = table.Column<string>(type: "text", nullable: true),
                    address_state = table.Column<string>(type: "text", nullable: true),
                    address_zip = table.Column<string>(type: "text", nullable: true),
                    address_country = table.Column<string>(type: "text", nullable: true),
                    home_phone = table.Column<string>(type: "text", nullable: true),
                    mobile_phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact_object", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "device",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    unique_id = table.Column<string>(type: "text", nullable: false),
                    position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    last_update = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_moved = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    speed_limit = table.Column<int>(type: "integer", nullable: false),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "device_command",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    delay = table.Column<int>(type: "integer", nullable: false),
                    messages = table.Column<string>(type: "text", nullable: false),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_command", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "device_position",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    device_id = table.Column<Guid>(type: "uuid", nullable: false),
                    time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    server_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    speed = table.Column<double>(type: "double precision", nullable: false),
                    course = table.Column<double>(type: "double precision", nullable: false),
                    distance = table.Column<double>(type: "double precision", nullable: false),
                    odometer = table.Column<double>(type: "double precision", nullable: false),
                    altitude = table.Column<double>(type: "double precision", nullable: false),
                    satellites = table.Column<int>(type: "integer", nullable: false),
                    fuel = table.Column<double>(type: "double precision", nullable: true),
                    battery = table.Column<double>(type: "double precision", nullable: true),
                    charging = table.Column<bool>(type: "boolean", nullable: false),
                    location_ids = table.Column<Guid[]>(type: "uuid[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_position", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    server_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    device_id = table.Column<Guid>(type: "uuid", nullable: true),
                    position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    location_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "location_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_location_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    approved_by = table.Column<Guid>(type: "uuid", nullable: true),
                    approved_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true),
                    speed_limit = table.Column<int>(type: "integer", nullable: true),
                    rest_duration = table.Column<decimal>(type: "numeric", nullable: false),
                    tolerance_duration = table.Column<decimal>(type: "numeric", nullable: false),
                    completed_rate = table.Column<int>(type: "integer", nullable: true),
                    source = table.Column<Point>(type: "geometry", nullable: false),
                    destination = table.Column<Point>(type: "geometry", nullable: false),
                    path = table.Column<LineString>(type: "geometry", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_routes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tag_members",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_members", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant_branch",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    address_line1 = table.Column<string>(type: "text", nullable: true),
                    address_line2 = table.Column<string>(type: "text", nullable: true),
                    address_city = table.Column<string>(type: "text", nullable: true),
                    address_county = table.Column<string>(type: "text", nullable: true),
                    address_state = table.Column<string>(type: "text", nullable: true),
                    address_zip = table.Column<string>(type: "text", nullable: true),
                    address_country = table.Column<string>(type: "text", nullable: true),
                    home_phone = table.Column<string>(type: "text", nullable: true),
                    mobile_phone = table.Column<string>(type: "text", nullable: true),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_branch", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant_domains",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    domain = table.Column<string>(type: "text", nullable: false),
                    registrar = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_domains", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant_map_option",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    map_type = table.Column<string>(type: "text", nullable: true),
                    zoom = table.Column<int>(type: "integer", nullable: true),
                    zoom_selection = table.Column<int>(type: "integer", nullable: true),
                    enable_trip = table.Column<bool>(type: "boolean", nullable: false),
                    auto_route = table.Column<bool>(type: "boolean", nullable: false),
                    auto_order = table.Column<bool>(type: "boolean", nullable: false),
                    auto_route_cost = table.Column<bool>(type: "boolean", nullable: false),
                    auto_invoice = table.Column<bool>(type: "boolean", nullable: false),
                    verify_otp = table.Column<bool>(type: "boolean", nullable: false),
                    auto_zone_otp = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_map_option", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<string>(type: "text", nullable: true),
                    language = table.Column<string>(type: "text", nullable: true),
                    timezone = table.Column<string>(type: "text", nullable: true),
                    hour24time = table.Column<bool>(type: "boolean", nullable: false),
                    unit_distance = table.Column<string>(type: "text", nullable: true),
                    unit_volume = table.Column<string>(type: "text", nullable: true),
                    unit_weight = table.Column<string>(type: "text", nullable: true),
                    unit_temperature = table.Column<string>(type: "text", nullable: true),
                    unit_speed = table.Column<string>(type: "text", nullable: true),
                    unit_power = table.Column<string>(type: "text", nullable: true),
                    unit_pressure = table.Column<string>(type: "text", nullable: true),
                    unit_force = table.Column<string>(type: "text", nullable: true),
                    unit_area = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    unique_id = table.Column<int>(type: "integer", nullable: false),
                    logo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: true),
                    module = table.Column<string>(type: "text", nullable: true),
                    feature = table.Column<string>(type: "text", nullable: true),
                    actions_create = table.Column<bool>(type: "boolean", nullable: false),
                    actions_delete = table.Column<bool>(type: "boolean", nullable: false),
                    actions_read = table.Column<bool>(type: "boolean", nullable: false),
                    actions_update = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_permissions_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "asset",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    barcode = table.Column<string>(type: "text", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asset", x => x.id);
                    table.ForeignKey(
                        name: "fk_asset_asset_category_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trailer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    fleet_identifier = table.Column<string>(type: "text", nullable: true),
                    odometer = table.Column<long>(type: "bigint", nullable: false),
                    horse_power = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    weight_capacity = table.Column<decimal>(type: "numeric", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    barcode = table.Column<string>(type: "text", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trailer", x => x.id);
                    table.ForeignKey(
                        name: "fk_trailer_asset_category_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    fleet_identifier = table.Column<string>(type: "text", nullable: false),
                    registration_no = table.Column<string>(type: "text", nullable: true),
                    odometer = table.Column<long>(type: "bigint", nullable: false),
                    fuel_type = table.Column<int>(type: "integer", nullable: false),
                    fuel_capacity = table.Column<int>(type: "integer", nullable: false),
                    horse_power = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "text", nullable: true),
                    weight_capacity = table.Column<decimal>(type: "numeric", nullable: false),
                    trailer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    barcode = table.Column<string>(type: "text", nullable: true),
                    color = table.Column<string>(type: "text", nullable: true),
                    deployed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    decommissioned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicle_asset_category_category_id",
                        column: x => x.category_id,
                        principalTable: "asset_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    middle_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    extra_information_id = table.Column<Guid>(type: "uuid", nullable: true),
                    expiry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    last_active = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contact", x => x.id);
                    table.ForeignKey(
                        name: "fk_contact_contact_object_extra_information_id",
                        column: x => x.extra_information_id,
                        principalTable: "contact_object",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    approved_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    approved_by = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    geometry = table.Column<Geometry>(type: "geometry", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_location", x => x.id);
                    table.ForeignKey(
                        name: "fk_location_location_category_category_id",
                        column: x => x.category_id,
                        principalTable: "location_category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contact_id = table.Column<Guid>(type: "uuid", nullable: true),
                    default_role = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_users_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_asp_net_users_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "lead",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contact_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tag_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lead", x => x.id);
                    table.ForeignKey(
                        name: "fk_lead_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true),
                    contact_id = table.Column<Guid>(type: "uuid", nullable: true),
                    lead_id = table.Column<Guid>(type: "uuid", nullable: true),
                    location_id = table.Column<Guid>(type: "uuid", nullable: true),
                    routes_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.id);
                    table.ForeignKey(
                        name: "fk_tags_contact_contact_id",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tags_lead_lead_id",
                        column: x => x.lead_id,
                        principalTable: "lead",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tags_location_location_id",
                        column: x => x.location_id,
                        principalTable: "location",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tags_routes_routes_id",
                        column: x => x.routes_id,
                        principalTable: "routes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_map_option_deleted_at",
                table: "account_map_option",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_account_map_option_tenant_id",
                table: "account_map_option",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_map_option_user_id",
                table: "account_map_option",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_notification_deleted_at",
                table: "account_notification",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_account_notification_tenant_id",
                table: "account_notification",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_notification_user_id",
                table: "account_notification",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_settings_deleted_at",
                table: "account_settings",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_account_settings_tenant_id",
                table: "account_settings",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_settings_user_id",
                table: "account_settings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_contact_id",
                table: "AspNetUsers",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_email",
                table: "AspNetUsers",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_role_id",
                table: "AspNetUsers",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_tenant_id",
                table: "AspNetUsers",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_user_name",
                table: "AspNetUsers",
                column: "user_name");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asset_category_id",
                table: "asset",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_asset_deleted_at",
                table: "asset",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_contact_deleted_at",
                table: "contact",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_contact_extra_information_id",
                table: "contact",
                column: "extra_information_id");

            migrationBuilder.CreateIndex(
                name: "ix_lead_contact_id",
                table: "lead",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_lead_deleted_at",
                table: "lead",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_location_category_id",
                table: "location",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_location_deleted_at",
                table: "location",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_routes_deleted_at",
                table: "routes",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tag_members_deleted_at",
                table: "tag_members",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tags_contact_id",
                table: "tags",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_deleted_at",
                table: "tags",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tags_lead_id",
                table: "tags",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_location_id",
                table: "tags",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "ix_tags_routes_id",
                table: "tags",
                column: "routes_id");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_domains_deleted_at",
                table: "tenant_domains",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_domains_domain",
                table: "tenant_domains",
                column: "domain");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_domains_expiry",
                table: "tenant_domains",
                column: "expiry");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_map_option_deleted_at",
                table: "tenant_map_option",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tenant_settings_deleted_at",
                table: "tenant_settings",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_tenants_unique_id",
                table: "tenants",
                column: "unique_id");

            migrationBuilder.CreateIndex(
                name: "ix_trailer_category_id",
                table: "trailer",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_trailer_deleted_at",
                table: "trailer",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_deleted_at",
                table: "user_permissions",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_user_permissions_role_id",
                table: "user_permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_category_id",
                table: "vehicle",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_deleted_at",
                table: "vehicle",
                column: "deleted_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_map_option");

            migrationBuilder.DropTable(
                name: "account_notification");

            migrationBuilder.DropTable(
                name: "account_settings");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "asset");

            migrationBuilder.DropTable(
                name: "device");

            migrationBuilder.DropTable(
                name: "device_command");

            migrationBuilder.DropTable(
                name: "device_position");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "tag_members");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "tenant_branch");

            migrationBuilder.DropTable(
                name: "tenant_domains");

            migrationBuilder.DropTable(
                name: "tenant_map_option");

            migrationBuilder.DropTable(
                name: "tenant_settings");

            migrationBuilder.DropTable(
                name: "tenants");

            migrationBuilder.DropTable(
                name: "trailer");

            migrationBuilder.DropTable(
                name: "user_permissions");

            migrationBuilder.DropTable(
                name: "vehicle");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "lead");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "asset_category");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "location_category");

            migrationBuilder.DropTable(
                name: "contact_object");
        }
    }
}
