using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceRequest.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EngineeringServiceRequests",
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
                    table.PrimaryKey("PK_EngineeringServiceRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngineeringServiceRequests");
        }
    }
}
