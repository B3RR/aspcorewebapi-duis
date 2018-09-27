using Microsoft.EntityFrameworkCore.Migrations;

namespace aspcorewebapiduis.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 4, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    FIO = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationName = table.Column<string>(maxLength: 255, nullable: false),
                    Controller = table.Column<string>(maxLength: 255, nullable: false),
                    DuisId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rules_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RoleUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 1, "GET", "S" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 15, "DELETE,PUT,POST,GET", "DUIS" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 14, "DELETE,PUT,POST", "DUI" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 13, "DELETE,PUT,GET", "DUS" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 12, "DELETE,PUT", "DU" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 11, "DELETE,POST,GET", "DIS" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 10, "DELETE,POST", "DI" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 9, "DELETE,GET", "DS" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 7, "PUT,POST,GET", "UIS" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 6, "PUT,POST", "UI" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 5, "PUT,GET", "US" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 4, "PUT", "U" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 3, "POST,GET", "IS" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 2, "POST", "I" });

            migrationBuilder.InsertData(
                table: "Duis",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 8, "DELETE", "D" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 2, "Пользователь", "User" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 1, "Администратор", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "FIO", "Login" },
                values: new object[] { 1, "ber.oleg@gmail.com", "Администратор", "Admin" });

            migrationBuilder.InsertData(
                table: "RoleUsers",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Rules",
                columns: new[] { "ID", "ApplicationName", "Controller", "DuisId", "RoleId" },
                values: new object[] { 1, "aspcorewebapi-duis", "userinfo", 15, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Duis_ID",
                table: "Duis",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Duis_Name",
                table: "Duis",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_UserId",
                table: "RoleUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_RoleId_Controller_ApplicationName",
                table: "Rules",
                columns: new[] { "RoleId", "Controller", "ApplicationName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duis");

            migrationBuilder.DropTable(
                name: "RoleUsers");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
