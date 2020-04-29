using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PORM
{
    public class Contexto: DbContext
    {

        private DbSet<Producto> producto;
        private DbSet<Cliente> cliente;
        private DbSet<Venta> venta;

        public DbSet<Producto> Producto { get => producto; set => producto = value; }
        public DbSet<Cliente> Cliente { get => cliente; set => cliente = value; }
        public DbSet<Venta> Venta { get => venta; set => venta = value; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7H9VS1J;Database=Trabajo;Trusted_Connection=True;");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");
                entity.HasData(new Producto {ProductoID=1 ,  Codigo = "0054SS", Marca = "Adidas", Precio = 12, Nombre = "zapatillas"  });
                entity.HasData(new Producto { ProductoID = 2, Codigo = "0054S1", Marca = "Nike", Precio = 12, Nombre = "gorra" });
                entity.HasData(new Producto { ProductoID = 3, Codigo = "0054S2", Marca = "Rebook", Precio = 12, Nombre = "ojotas" });
                entity.HasData(new Producto { ProductoID = 4, Codigo = "0054S3", Marca = "Lecof", Precio = 12, Nombre = "buzo" });
                entity.HasData(new Producto { ProductoID = 5, Codigo = "0054S4", Marca = "Chester", Precio = 12, Nombre = "campera" });
            });
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasData(new Cliente {ClienteID=1, Nombre="Alan", Apellido="Marengo", Direccion="154", Dni="4055585", Telefono="55445454577" });
                entity.HasData(new Cliente { ClienteID =2, Nombre ="Maty", Apellido ="Ayala", Direccion ="155", Dni ="40555598", Telefono ="545454554" });
                entity.HasData(new Cliente { ClienteID =3, Nombre ="Ema", Apellido ="Julio", Direccion ="156", Dni ="5454545454", Telefono ="877878112" });
                entity.HasData(new Cliente { ClienteID =4, Nombre ="Octavio", Apellido ="Octavio", Direccion ="157", Dni ="875454", Telefono ="989889889" });
                entity.HasData(new Cliente { ClienteID =5, Nombre ="David", Apellido ="Cataneo", Direccion ="158", Dni ="87541", Telefono ="21221122" });
                entity.HasData(new Cliente { ClienteID =6, Nombre ="Javier", Apellido ="Javier", Direccion ="159", Dni ="12112445", Telefono ="8877844" });
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Venta");
                entity.HasData(new Venta {VentaID=1, Fecha=DateTime.Today, ClienteID=1, ProductoID=2});
                entity.HasData(new Venta { VentaID = 2, Fecha = DateTime.Today, ClienteID = 2, ProductoID = 1 });
                entity.HasData(new Venta { VentaID = 3, Fecha = DateTime.Today, ClienteID = 3, ProductoID =4 });
                entity.HasData(new Venta { VentaID = 4, Fecha = DateTime.Today, ClienteID = 4, ProductoID = 5 });
                entity.HasData(new Venta { VentaID = 5, Fecha = DateTime.Today, ClienteID = 5, ProductoID = 3 });
            });
        }





    }
}
