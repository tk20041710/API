using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandAPI.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGenre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("13936f36-4830-4e71-a83c-212a494b62be"), new Guid("77e0a4a9-0038-4114-8740-cc031f38e222"), "Description 1", "New 1" },
                    { new Guid("ca014910-8d1c-4904-b3a0-6870cca54522"), new Guid("efc3f365-1797-4b9e-be9b-aefd7a3f533f"), "Description 1", "New 1" },
                    { new Guid("12278022-8c57-4b82-81a1-abe59a5fef92"), new Guid("77e0a4a9-0038-4114-8740-cc031f38e222"), "Description 1", "New 1" }
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { new Guid("77e0a4a9-0038-4114-8740-cc031f38e222"), new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "A" },
                    { new Guid("db2baa95-d123-4f5c-9402-79b414c6392d"), new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "New" },
                    { new Guid("efc3f365-1797-4b9e-be9b-aefd7a3f533f"), new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "B" },
                    { new Guid("487142e9-5f83-4e65-9ebc-975bb42018a5"), new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "C" },
                    { new Guid("adcac28c-703c-4eca-9ef7-9a0c29478c5f"), new DateTime(1999, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "D" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
