using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Citador.Migrations
{
  public partial class InitialCreate : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Users",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Email = table.Column<string>(maxLength: 100, nullable: true),
            LastName = table.Column<string>(maxLength: 80, nullable: true),
            Name = table.Column<string>(maxLength: 80, nullable: true),
            Password = table.Column<string>(maxLength: 120, nullable: true),
            Username = table.Column<string>(maxLength: 60, nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Users", x => x.Id);
            table.UniqueConstraint("U_Email", x => x.Email);
            table.UniqueConstraint("U_Username", x => x.Username);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Users");
    }
  }
}
