using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReimbursementParkingAPI.Migrations
{
    public partial class adddatenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ManagerResponseTime",
                table: "tb_request-reimbursement-parking",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "HRDResponseTime",
                table: "tb_request-reimbursement-parking",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ManagerResponseTime",
                table: "tb_request-reimbursement-parking",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "HRDResponseTime",
                table: "tb_request-reimbursement-parking",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);
        }
    }
}
