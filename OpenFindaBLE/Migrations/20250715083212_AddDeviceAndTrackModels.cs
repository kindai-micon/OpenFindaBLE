using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenFindaBLE.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceAndTrackModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authorities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authorities_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EncryptionKey = table.Column<byte[]>(type: "bytea", nullable: false),
                    VarificationKey = table.Column<byte[]>(type: "bytea", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    AccelerationX = table.Column<double>(type: "double precision", nullable: false),
                    AccelerationY = table.Column<double>(type: "double precision", nullable: false),
                    AccelerationZ = table.Column<double>(type: "double precision", nullable: false),
                    GyroX = table.Column<double>(type: "double precision", nullable: false),
                    GyroY = table.Column<double>(type: "double precision", nullable: false),
                    GyroZ = table.Column<double>(type: "double precision", nullable: false),
                    ReceiveTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reliability = table.Column<int>(type: "integer", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackLog_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDevice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Attribute = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDevice_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDevice_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authorities_RoleId",
                table: "Authorities",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackLog_DeviceId",
                table: "TrackLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevice_ApplicationUserId",
                table: "UserDevice",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevice_DeviceId",
                table: "UserDevice",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authorities");

            migrationBuilder.DropTable(
                name: "TrackLog");

            migrationBuilder.DropTable(
                name: "UserDevice");

            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
