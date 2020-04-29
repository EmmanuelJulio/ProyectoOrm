using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace PORM
{
    public class CRUD
    {
        static CRUD instance = null;


        public static CRUD getInstance()
        {
            if (instance == null)
            {
                instance = new CRUD();
                
            }
            return instance;
        }

        private CRUD()
        {

        }

        public List<Cliente> TraerClientes()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Cliente> lista = (from x in contexto.Cliente  select x).ToList();
                return lista;

            }
        }
        public List<Cliente> TraerClientesID(int ID)
        {
            using (Contexto contexto = new Contexto())
            {
                List<Cliente> lista = (from x in contexto.Cliente where x.ClienteID==ID select x).ToList();
                return lista;

            }
        }
        public string MostrarClienteId(int ID)
        {
            using (Contexto contexto = new Contexto())
            {
                string nombre = (from x in contexto.Cliente where x.ClienteID == ID select x.Nombre).FirstOrDefault();
                return nombre;
            }
        }


        public Cliente BuscarClienteDNI(string DNI)
        {
            using (Contexto contexto = new Contexto())
            {
                Cliente cliente = (from x in contexto.Cliente where x.Dni == DNI select x).FirstOrDefault();
                return cliente;
            }

        }

      

        public List<Producto> TraerProductos()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Producto> lista = (from x in contexto.Producto select x).ToList();
                return lista;

            }
        }
        public List<Producto> TraerProductosID(int ID)
        {
            using (Contexto contexto = new Contexto())
            {
                List<Producto> lista = (from x in contexto.Producto where x.ProductoID==ID select x).ToList();
                return lista;

            }
        }

        public List<string> NombreProducto()
        {
            List<string> nombres = new List<string>();
            foreach(Producto producto in TraerProductos())
            {
                nombres.Add(producto.Nombre);
            }
            return nombres;
            
        }

        public void TraerProductosMenu()
        {
            List<string> nombres = NombreProducto();
            for (int x = 0; x < nombres.Count(); x++)
            {
                Console.WriteLine(x+1 + ")" + " "+nombres[x]);
            }
            Console.WriteLine(nombres.Count() + 1+")"+" "+"Salir");
        }

        public string MostrarProductoID(int ID)
        {
            using (Contexto contexto = new Contexto())
            {
                string nombre = (from x in contexto.Producto where x.ProductoID == ID select x.Nombre).FirstOrDefault();
                return nombre;
            }
        }
        public List<Venta> TraerVentas()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Venta> lista = (from x in contexto.Venta select x).ToList();
                return lista;

            }
        }
        public List<Venta> TraerVentasDelDia()
        {
            using (Contexto contexto = new Contexto())
            {
                List<Venta> lista = (from x in contexto.Venta where x.Fecha==DateTime.Today select x).ToList();
                return lista; 

            }
        }    
        public void RealizarVenta(Cliente cliente, Producto producto)
        {
            using (Contexto contexto = new Contexto())
            {
                Venta venta = new Venta();
                {
                    venta.Fecha = DateTime.Today;
                    venta.ClienteID = cliente.ClienteID;
                    venta.ProductoID = producto.ProductoID;
                   

                };
                contexto.Venta.Add(venta);
                contexto.SaveChanges();
            }
        }

        
        public void MostrarVentaMenu()
        {
            foreach (Venta venta in TraerVentas())
            {
                Console.WriteLine("Producto: "+" "+MostrarProductoID(venta.ProductoID)+" "+"Cliente : "+" "+MostrarClienteId(venta.ClienteID)+ " "+"Fecha de compra :"+" "+venta.Fecha);
            }
        }



        public void MostrarVentasDelDiaMenu()
        {
            foreach (Venta venta in TraerVentasDelDia())
            {
                Console.WriteLine("Producto: " + " " + MostrarProductoID(venta.ProductoID) + " " + "Cliente : " + " " + MostrarClienteId(venta.ClienteID) + " " + "Fecha de compra :" + " " + venta.Fecha);
            }
        }








    }
}
