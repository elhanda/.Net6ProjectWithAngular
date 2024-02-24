using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.Store.Migrations
{
    public partial class update_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppProduct",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppOrderItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppOrder",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppCustomer",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppProduct");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppOrderItem");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppOrder");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppCustomer");
        }
    }
}
