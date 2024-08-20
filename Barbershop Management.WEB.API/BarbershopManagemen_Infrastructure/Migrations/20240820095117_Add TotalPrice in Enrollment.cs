using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarbershopManagemen_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalPriceinEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Enrollment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Enrollment");
        }
    }
}
