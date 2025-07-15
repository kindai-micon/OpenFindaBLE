using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenFindaBLE.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceModelDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackLog_Device_DeviceId",
                table: "TrackLog");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDevice_AspNetUsers_ApplicationUserId",
                table: "UserDevice");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDevice_Device_DeviceId",
                table: "UserDevice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDevice",
                table: "UserDevice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackLog",
                table: "TrackLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.RenameTable(
                name: "UserDevice",
                newName: "UserDevices");

            migrationBuilder.RenameTable(
                name: "TrackLog",
                newName: "TrackLogs");

            migrationBuilder.RenameTable(
                name: "Device",
                newName: "Devices");

            migrationBuilder.RenameIndex(
                name: "IX_UserDevice_DeviceId",
                table: "UserDevices",
                newName: "IX_UserDevices_DeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDevice_ApplicationUserId",
                table: "UserDevices",
                newName: "IX_UserDevices_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TrackLog_DeviceId",
                table: "TrackLogs",
                newName: "IX_TrackLogs_DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDevices",
                table: "UserDevices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackLogs",
                table: "TrackLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackLogs_Devices_DeviceId",
                table: "TrackLogs",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDevices_AspNetUsers_ApplicationUserId",
                table: "UserDevices",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDevices_Devices_DeviceId",
                table: "UserDevices",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackLogs_Devices_DeviceId",
                table: "TrackLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDevices_AspNetUsers_ApplicationUserId",
                table: "UserDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDevices_Devices_DeviceId",
                table: "UserDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDevices",
                table: "UserDevices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackLogs",
                table: "TrackLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.RenameTable(
                name: "UserDevices",
                newName: "UserDevice");

            migrationBuilder.RenameTable(
                name: "TrackLogs",
                newName: "TrackLog");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Device");

            migrationBuilder.RenameIndex(
                name: "IX_UserDevices_DeviceId",
                table: "UserDevice",
                newName: "IX_UserDevice_DeviceId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDevices_ApplicationUserId",
                table: "UserDevice",
                newName: "IX_UserDevice_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TrackLogs_DeviceId",
                table: "TrackLog",
                newName: "IX_TrackLog_DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDevice",
                table: "UserDevice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackLog",
                table: "TrackLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackLog_Device_DeviceId",
                table: "TrackLog",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDevice_AspNetUsers_ApplicationUserId",
                table: "UserDevice",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDevice_Device_DeviceId",
                table: "UserDevice",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
