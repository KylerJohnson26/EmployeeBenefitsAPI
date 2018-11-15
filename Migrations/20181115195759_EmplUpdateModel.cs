using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BenefitsManagementAPI.Migrations
{
    public partial class EmplUpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AnnualCostOfBenefits",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostOfBenefitsPerPayPeriod",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualCostOfBenefits",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CostOfBenefitsPerPayPeriod",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Employees");
        }
    }
}
