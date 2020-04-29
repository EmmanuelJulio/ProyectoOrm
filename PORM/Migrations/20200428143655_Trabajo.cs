using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PORM.Migrations
{
    public partial class Trabajo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoID);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoID = table.Column<int>(nullable: false),
                    ClienteID = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaID);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Producto_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteID", "Apellido", "Direccion", "Dni", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Marengo", "154", "4055585", "Alan", "55445454577" },
                    { 2, "Ayala", "155", "40555598", "Maty", "545454554" },
                    { 3, "Julio", "156", "5454545454", "Ema", "877878112" },
                    { 4, "Octavio", "157", "875454", "Octavio", "989889889" },
                    { 5, "Cataneo", "158", "87541", "David", "21221122" },
                    { 6, "Javier", "159", "12112445", "Javier", "8877844" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoID", "Codigo", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "0054SS", "Adidas", "zapatillas", 12m },
                    { 2, "0054S1", "Nike", "gorra", 12m },
                    { 3, "0054S2", "Rebook", "ojotas", 12m },
                    { 4, "0054S3", "Lecof", "buzo", 12m },
                    { 5, "0054S4", "Chester", "campera", 12m }
                });

            migrationBuilder.InsertData(
                table: "Venta",
                columns: new[] { "VentaID", "ClienteID", "Fecha", "ProductoID" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 1, 1, new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 5, 5, new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 3, 3, new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 4, 4, new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Local), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteID",
                table: "Venta",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ProductoID",
                table: "Venta",
                column: "ProductoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
