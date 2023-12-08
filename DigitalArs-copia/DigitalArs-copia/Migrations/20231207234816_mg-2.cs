using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalArs_copia.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_Users_user_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_roles_role_id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_Users_role_id",
                table: "users",
                newName: "IX_users_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "user_id");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "role_id", "role_description", "role_name" },
                values: new object[] { 1, "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "role_id", "role_description", "role_name" },
                values: new object[] { 2, "Consultant", "Consultant" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "user_email", "user_firstName", "user_lastName", "user_password", "role_id" },
                values: new object[,]
                {
                    { 1, "adm@gmail.com", "Pablo", "Ortiz", "9f3d321cd0a1ccafa899226d5190f74618cb23b789aa998e1d7f741956132434", 1 },
                    { 2, "noadm@gmail.com", "Kevin", "Johnson", "a10ad3a74bccd29b56cb5ec5a213d1a27b293b6bb88797418a31f09c2a707bf4", 2 },
                    { 3, "bob@example.com", "Bob", "Smith", "a10ad3a74bccd29b56cb5ec5a213d1a27b293b6bb88797418a31f09c2a707bf4", 1 },
                    { 4, "eva@example.com", "Eva", "Lee", "ff192a780cb98e260d87c38683c2e155dfe48897e454e47390063fd76755651f", 2 },
                    { 5, "john@example.com", "John", "Doe", "fbafa90f00f6416a6d1e8535234f9603aaf07258d7a98424ec011a5f7aa634ff", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_users_user_id",
                table: "accounts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_users_user_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "role_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "role_id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_users_role_id",
                table: "Users",
                newName: "IX_Users_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_Users_user_id",
                table: "accounts",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_roles_role_id",
                table: "Users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
