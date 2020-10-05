using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReimbursementParkingAPI.Migrations
{
    public partial class recreateID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_request_reimbursement_status_enum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_request_reimbursement_status_enum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_request_reimbursement_parking",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    RejectReason = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTimeOffset>(nullable: false),
                    HRDResponseTime = table.Column<DateTimeOffset>(nullable: true),
                    ManagerResponseTime = table.Column<DateTimeOffset>(nullable: true),
                    RequestReimbursementStatusEnumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_request_reimbursement_parking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_t_request_reimbursement_parking_tb_m_request_reimbursement_status_enum_RequestReimbursementStatusEnumId",
                        column: x => x.RequestReimbursementStatusEnumId,
                        principalTable: "tb_m_request_reimbursement_status_enum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_blob",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_blob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_t_blob_tb_t_request_reimbursement_parking_Id",
                        column: x => x.Id,
                        principalTable: "tb_t_request_reimbursement_parking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_t_reimbursement_detail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PLATNumber = table.Column<string>(nullable: true),
                    Periode = table.Column<string>(nullable: true),
                    VechicleType = table.Column<string>(nullable: true),
                    PaymentType = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<int>(nullable: false),
                    VechicleOwner = table.Column<string>(nullable: true),
                    ParkingName = table.Column<string>(nullable: true),
                    ParkingAddress = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_t_reimbursement_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_t_reimbursement_detail_tb_t_request_reimbursement_parking_Id",
                        column: x => x.Id,
                        principalTable: "tb_t_request_reimbursement_parking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_request_reimbursement_parking_RequestReimbursementStatusEnumId",
                table: "tb_t_request_reimbursement_parking",
                column: "RequestReimbursementStatusEnumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_t_blob");

            migrationBuilder.DropTable(
                name: "tb_t_reimbursement_detail");

            migrationBuilder.DropTable(
                name: "tb_t_request_reimbursement_parking");

            migrationBuilder.DropTable(
                name: "tb_m_request_reimbursement_status_enum");
        }
    }
}
