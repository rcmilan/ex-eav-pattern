using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAV.api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:attribute_value_type", "text,integer,decimal,boolean,date,custom_object");

            migrationBuilder.CreateTable(
                name: "CustomEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ValueType = table.Column<string>(type: "text", nullable: false),
                    CustomEntityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomAttributes_CustomEntities_CustomEntityId",
                        column: x => x.CustomEntityId,
                        principalTable: "CustomEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ValueData = table.Column<string>(type: "text", nullable: false),
                    CustomAttributeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomValues_CustomAttributes_CustomAttributeId",
                        column: x => x.CustomAttributeId,
                        principalTable: "CustomAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomAttributes_CustomEntityId",
                table: "CustomAttributes",
                column: "CustomEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomValues_CustomAttributeId",
                table: "CustomValues",
                column: "CustomAttributeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomValues");

            migrationBuilder.DropTable(
                name: "CustomAttributes");

            migrationBuilder.DropTable(
                name: "CustomEntities");
        }
    }
}
