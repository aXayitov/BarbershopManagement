using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarbershopManagemen_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusforEnrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Enrollment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Enrollment");
        }
    }
}
