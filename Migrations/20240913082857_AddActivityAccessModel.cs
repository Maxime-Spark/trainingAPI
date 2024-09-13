using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    public partial class AddActivityAccessModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityAccesses_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityAccesses_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$hL1ZHNcYllHdxg54utYpCuTIvf4yIyxbkYkyRks/mppim5qqYHFRK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$hL1ZHNcYllHdxg54utYpCuTIvf4yIyxbkYkyRks/mppim5qqYHFRK");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAccesses_ActivityId",
                table: "ActivityAccesses",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAccesses_GroupId",
                table: "ActivityAccesses",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityAccesses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Registrations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$M4hRB64qXNR3Yy8SQ3O74O60kfVRCPeJgJcoCGUDkq7h0VHsGY5nS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$M4hRB64qXNR3Yy8SQ3O74O60kfVRCPeJgJcoCGUDkq7h0VHsGY5nS");
        }
    }
}
