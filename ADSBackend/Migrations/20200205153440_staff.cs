using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSBackend.Migrations
{
    public partial class staff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.RenameColumn(
                name: "Counselor",
                table: "Appointment",
                newName: "Counselorid");

            migrationBuilder.AlterColumn<string>(
                name: "Counselorid",
                table: "Appointment",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Counselorid",
                table: "Appointment",
                column: "Counselorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Staff_Counselorid",
                table: "Appointment",
                column: "Counselorid",
                principalTable: "Staff",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Staff_Counselorid",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_Counselorid",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "Counselorid",
                table: "Appointment",
                newName: "Counselor");

            migrationBuilder.AlterColumn<string>(
                name: "Counselor",
                table: "Appointment",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.id);
                });
        }
    }
}
