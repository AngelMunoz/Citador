using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Citador.Migrations
{
  public partial class AddAddressAndContact : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {

      migrationBuilder.CreateTable(
          name: "Addresses",
          columns: table => new
          {
            Id = table.Column<uint>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            City = table.Column<string>(maxLength: 70, nullable: true),
            Country = table.Column<string>(maxLength: 65, nullable: true),
            Line1 = table.Column<string>(maxLength: 100, nullable: true),
            Line2 = table.Column<string>(maxLength: 100, nullable: true),
            PostalCode = table.Column<uint>(maxLength: 10, nullable: false),
            State = table.Column<string>(maxLength: 65, nullable: true),
            UserId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Addresses", x => x.Id);
            table.ForeignKey(
                      name: "FK_Addresses_Users_UserId",
                      column: x => x.UserId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "ContactInfos",
          columns: table => new
          {
            Id = table.Column<uint>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Email2 = table.Column<string>(maxLength: 120, nullable: true),
            Phone = table.Column<string>(maxLength: 40, nullable: true),
            Phone2 = table.Column<string>(maxLength: 40, nullable: true),
            UserId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ContactInfos", x => x.Id);
            table.ForeignKey(
                      name: "FK_ContactInfos_Users_UserId",
                      column: x => x.UserId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Addresses_UserId",
          table: "Addresses",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_ContactInfos_UserId",
          table: "ContactInfos",
          column: "UserId");

    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Addresses");

      migrationBuilder.DropTable(
          name: "ContactInfos");
    }
  }
}
