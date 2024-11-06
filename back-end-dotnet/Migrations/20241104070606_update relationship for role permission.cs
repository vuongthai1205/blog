using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationshipforrolepermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionEntityRoleEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionEntityRoleEntity",
                columns: table => new
                {
                    PermissionEntitiesPermissionId = table.Column<int>(type: "int", nullable: false),
                    RoleEntitiesRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionEntityRoleEntity", x => new { x.PermissionEntitiesPermissionId, x.RoleEntitiesRoleId });
                    table.ForeignKey(
                        name: "FK_PermissionEntityRoleEntity_permission_PermissionEntitiesPermissionId",
                        column: x => x.PermissionEntitiesPermissionId,
                        principalTable: "permission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionEntityRoleEntity_role_RoleEntitiesRoleId",
                        column: x => x.RoleEntitiesRoleId,
                        principalTable: "role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionEntityRoleEntity_RoleEntitiesRoleId",
                table: "PermissionEntityRoleEntity",
                column: "RoleEntitiesRoleId");
        }
    }
}
