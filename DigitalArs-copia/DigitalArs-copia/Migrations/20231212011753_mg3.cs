using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalArs_copia.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 3,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 4,
                column: "is_active",
                value: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 5,
                column: "is_active",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "users");
        }
    }
}
