using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_Dono_GatoFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdDono",
                table: "Gatos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Donos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GatoFotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGato = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatoFotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GatoFotos_Gatos_IdGato",
                        column: x => x.IdGato,
                        principalTable: "Gatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gatos_IdDono",
                table: "Gatos",
                column: "IdDono");

            migrationBuilder.CreateIndex(
                name: "IX_GatoFotos_IdGato",
                table: "GatoFotos",
                column: "IdGato");

            migrationBuilder.AddForeignKey(
                name: "FK_Gatos_Donos_IdDono",
                table: "Gatos",
                column: "IdDono",
                principalTable: "Donos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gatos_Donos_IdDono",
                table: "Gatos");

            migrationBuilder.DropTable(
                name: "Donos");

            migrationBuilder.DropTable(
                name: "GatoFotos");

            migrationBuilder.DropIndex(
                name: "IX_Gatos_IdDono",
                table: "Gatos");

            migrationBuilder.DropColumn(
                name: "IdDono",
                table: "Gatos");
        }
    }
}
