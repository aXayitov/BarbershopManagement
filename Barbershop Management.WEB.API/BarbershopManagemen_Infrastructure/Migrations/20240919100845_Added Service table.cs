using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarbershopManagemen_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedServicetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialPayment",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Enrollment");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_ServiceId",
                table: "Enrollment",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Service_ServiceId",
                table: "Enrollment",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Service_ServiceId",
                table: "Enrollment");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_ServiceId",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Enrollment");

            migrationBuilder.AddColumn<decimal>(
                name: "InitialPayment",
                table: "Enrollment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Enrollment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
