using Microsoft.EntityFrameworkCore.Migrations;

namespace ReimbursementParkingAPI.Migrations
{
    public partial class addDepartmentName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "tb_reimbursement-detail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "tb_reimbursement-detail");
        }
    }
}
