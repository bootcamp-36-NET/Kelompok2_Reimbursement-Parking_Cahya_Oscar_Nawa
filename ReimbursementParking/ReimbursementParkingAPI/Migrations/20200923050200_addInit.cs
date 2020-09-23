using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReimbursementParkingAPI.Migrations
{
    public partial class addInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_request-reimbursement-status-enum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_request-reimbursement-status-enum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_request-reimbursement-parking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RejectReason = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTimeOffset>(nullable: false),
                    HRDResponseTime = table.Column<DateTimeOffset>(nullable: false),
                    ManagerResponseTime = table.Column<DateTimeOffset>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    RequestReimbursementStatusEnumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_request-reimbursement-parking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_request-reimbursement-parking_tb_m_request-reimbursement-status-enum_RequestReimbursementStatusEnumId",
                        column: x => x.RequestReimbursementStatusEnumId,
                        principalTable: "tb_m_request-reimbursement-status-enum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_blob",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    RequestReimbursementParkingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_blob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_blob_tb_request-reimbursement-parking_RequestReimbursementParkingId",
                        column: x => x.RequestReimbursementParkingId,
                        principalTable: "tb_request-reimbursement-parking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_plat-number",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatNumber = table.Column<string>(nullable: true),
                    VechicleType = table.Column<string>(nullable: true),
                    PaymentType = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<int>(nullable: false),
                    VechicleOwner = table.Column<string>(nullable: true),
                    ParkingName = table.Column<string>(nullable: true),
                    ParkingAddress = table.Column<string>(nullable: true),
                    RequestReimbursementParkingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_plat-number", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_plat-number_tb_request-reimbursement-parking_RequestReimbursementParkingId",
                        column: x => x.RequestReimbursementParkingId,
                        principalTable: "tb_request-reimbursement-parking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_blob_RequestReimbursementParkingId",
                table: "tb_blob",
                column: "RequestReimbursementParkingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_plat-number_RequestReimbursementParkingId",
                table: "tb_plat-number",
                column: "RequestReimbursementParkingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_request-reimbursement-parking_RequestReimbursementStatusEnumId",
                table: "tb_request-reimbursement-parking",
                column: "RequestReimbursementStatusEnumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_blob");

            migrationBuilder.DropTable(
                name: "tb_plat-number");

            migrationBuilder.DropTable(
                name: "tb_request-reimbursement-parking");

            migrationBuilder.DropTable(
                name: "tb_m_request-reimbursement-status-enum");
        }
    }
}
