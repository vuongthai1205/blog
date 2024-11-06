using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationshipforuserrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleEntityUserEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleEntityUserEntity",
                columns: table => new
                {
                    RoleEntitiesRoleId = table.Column<int>(type: "int", nullable: false),
                    UserEntitiesUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntityUserEntity", x => new { x.RoleEntitiesRoleId, x.UserEntitiesUserId });
                    table.ForeignKey(
                        name: "FK_RoleEntityUserEntity_role_RoleEntitiesRoleId",
                        column: x => x.RoleEntitiesRoleId,
                        principalTable: "role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleEntityUserEntity_user_UserEntitiesUserId",
                        column: x => x.UserEntitiesUserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntityUserEntity_UserEntitiesUserId",
                table: "RoleEntityUserEntity",
                column: "UserEntitiesUserId");
        }
    }
}
