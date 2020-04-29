using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace PORM
{
    public class Carro
    {
        public List<string> productos;
       
        

        public void AgregarP(Producto producto)
        {
            productos.Add(producto.Nombre);

        }



        public void MostrarCarro()
        {
            for(int x=0; x < productos.Count(); x++)
            {
                Console.WriteLine(x+1 + ")" + " " + productos[x]);
            }
            Console.WriteLine(productos.Count() + 1 + ")" + " " + "Salir");
        }




        public Carro()
        {
            productos = new List<string>();
            
            
        }
          
    }
    }


        







    

