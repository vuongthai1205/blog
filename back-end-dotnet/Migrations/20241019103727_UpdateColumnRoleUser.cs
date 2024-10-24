using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnRoleUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RolePermission",
                table: "role_user",
                newName: "RoleUserId");

            migrationBuilder.RenameColumn(
                name: "RolePermission",
                table: "role_permission",
                newName: "RolePermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleUserId",
                table: "role_user",
                newName: "RolePermission");

            migrationBuilder.RenameColumn(
                name: "RolePermissionId",
                table: "role_permission",
                newName: "RolePermission");
        }
    }
}
