using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

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

            migrationBuilder.CreateTable(
                name: "role_permission",
                columns: table => new
                {
                    RolePermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionEntityId = table.Column<int>(type: "int", nullable: false),
                    RoleEntityId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_permission", x => x.RolePermission);
                    table.ForeignKey(
                        name: "FK_role_permission_permission_PermissionEntityId",
                        column: x => x.PermissionEntityId,
                        principalTable: "permission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_permission_role_RoleEntityId",
                        column: x => x.RoleEntityId,
                        principalTable: "role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEntityId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_post_user_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_user",
                columns: table => new
                {
                    RolePermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEntityId = table.Column<int>(type: "int", nullable: false),
                    RoleEntityId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_user", x => x.RolePermission);
                    table.ForeignKey(
                        name: "FK_role_user_role_RoleEntityId",
                        column: x => x.RoleEntityId,
                        principalTable: "role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_user_user_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_PermissionEntityRoleEntity_RoleEntitiesRoleId",
                table: "PermissionEntityRoleEntity",
                column: "RoleEntitiesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_post_UserEntityId",
                table: "post",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_PermissionEntityId",
                table: "role_permission",
                column: "PermissionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_RoleEntityId",
                table: "role_permission",
                column: "RoleEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_role_user_RoleEntityId",
                table: "role_user",
                column: "RoleEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_role_user_UserEntityId",
                table: "role_user",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntityUserEntity_UserEntitiesUserId",
                table: "RoleEntityUserEntity",
                column: "UserEntitiesUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionEntityRoleEntity");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "role_permission");

            migrationBuilder.DropTable(
                name: "role_user");

            migrationBuilder.DropTable(
                name: "RoleEntityUserEntity");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
