using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessments.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Phone_CountryCode = table.Column<int>(type: "int", nullable: false),
                    Contact_Phone_Number = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
