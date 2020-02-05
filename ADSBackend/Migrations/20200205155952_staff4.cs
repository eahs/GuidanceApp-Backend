using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSBackend.Migrations
{
    public partial class staff4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Staff_Counselorid",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "Counselorid",
                table: "Appointment",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "Counselorid",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Staff_Counselorid",
                table: "Appointment",
                column: "Counselorid",
                principalTable: "Staff",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
