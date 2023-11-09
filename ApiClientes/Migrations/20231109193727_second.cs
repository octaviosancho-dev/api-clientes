using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClientes.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Clientes",
                newName: "TelefonoCelular");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefonoCelular",
                table: "Clientes",
                newName: "Telefono");
        }
    }
}
