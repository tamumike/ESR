using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceRequest.API.Migrations
{
    public partial class AddDraft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngineeringServiceRequests");

            migrationBuilder.CreateTable(
                name: "RequestDrafts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requestor = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Deliverables = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    AFE = table.Column<string>(nullable: true),
                    PropertyCode = table.Column<string>(nullable: true),
                    ApprovedBudget = table.Column<decimal>(nullable: false),
                    ExpectedCost = table.Column<decimal>(nullable: false),
                    RequestorComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDrafts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requestor = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Deliverables = table.Column<string>(nullable: true),
                    RequestNumber = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    CoupaApprovedDate = table.Column<DateTime>(nullable: false),
                    AFE = table.Column<string>(nullable: true),
                    PropertyCode = table.Column<string>(nullable: true),
                    Engineer = table.Column<string>(nullable: true),
                    EngineerComment = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    ApprovedBudget = table.Column<decimal>(nullable: false),
                    PromiseDate = table.Column<DateTime>(nullable: false),
                    ExpectedCost = table.Column<decimal>(nullable: false),
                    RequestorComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestDrafts");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.CreateTable(
                name: "EngineeringServiceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AFE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoupaApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deliverables = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Engineer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineerComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromiseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PropertyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requestor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestorComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineeringServiceRequests", x => x.Id);
                });
        }
    }
}
