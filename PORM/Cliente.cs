using System;
using System.Collections.Generic;
using System.Text;

namespace PORM
{
    public class Cliente
    {
        private int clienteID;
        private string dni;
        private string nombre;
        private string apellido;
        private string direccion;
        private string telefono;
        Carro c = new Carro(); // carro del cliente

        public void agregarProductos(Producto producto) // metodos del carro del cliente
        {
            c.AgregarP(producto);
        }


        public void MostrarCarro() // métodos de el carro del cliente
        {
            c.MostrarCarro();
        }

        public int ClienteID { get => clienteID; set => clienteID = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
