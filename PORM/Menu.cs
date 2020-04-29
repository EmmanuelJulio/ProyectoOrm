using System;
using System.Collections.Generic;
using System.Text;

namespace PORM
{
    public partial class Menu
    {  
       public Cliente LOGUEO()
        {
            Console.WriteLine("DEBE LOGUEARSE CON SU DNI");
            Console.WriteLine("INGRESE SU DNI:");
            string DNI = Console.ReadLine();
            return CRUD.getInstance().BuscarClienteDNI(DNI);
            
        }

        public void MENUCLIENTE(Cliente cliente)
        {
            int opcion;
            do
            {
                Console.WriteLine("-------------------------BIENVENIDO-------------------------------------");
                Console.WriteLine("-------------------------SELECCIONE UNA OPCION-------------------------------------");
                Console.WriteLine("-------------------------1) Comprar-------------------------------------");
                Console.WriteLine("-------------------------2) Mostrar compras-------------------------------------");
                Console.WriteLine("-------------------------3)Volver-------------------------------------");
                Console.WriteLine("-------------------------4)Salir------------------------------------");
                Console.WriteLine("");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("SELECCIONE UNA OPCION");
                        Console.WriteLine("---------------------");
                        CRUD.getInstance().TraerProductosMenu();
                        int seleccion = int.Parse(Console.ReadLine());
                        List<Producto> producto = CRUD.getInstance().TraerProductos();
                        cliente.agregarProductos(producto[seleccion-1]);
                        CRUD.getInstance().RealizarVenta(cliente, producto[seleccion - 1]);
                        Console.ReadKey();
                        Console.Clear();
                        MENUCLIENTE(cliente);

                        break;
                    case 2:
                        Console.Clear();
                        cliente.MostrarCarro();
                        Console.ReadKey();
                        Console.Clear();
                        MENUCLIENTE(cliente);
                        break;
                    case 3:
                        Console.Clear();
                        menu();
                        break;
                    case 4:
                        return;
                }
            } while (opcion==4);

        }
        public void MENUADMIN()
        {
            int opcion;
            do
            {
                
                Console.WriteLine("-------------------------BIENVENIDO-------------------------------------");
                Console.WriteLine("-------------------------SELECCIONE UNA OPCION-------------------------------------");
                Console.WriteLine("-------------------------1) Mostrar productos-------------------------------------");
                Console.WriteLine("-------------------------2) Mostrar ventas-------------------------------------");
                Console.WriteLine("-------------------------3) Mostrar ventas del dia-------------------------------------");
                Console.WriteLine("-------------------------4)Volver------------------------------------");
                Console.WriteLine("");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        CRUD.getInstance().TraerProductosMenu();
                        Console.ReadKey();
                        Console.Clear();
                        MENUADMIN();
                        break;
                    case 2:
                        Console.Clear();
                        CRUD.getInstance().MostrarVentaMenu();
                        Console.ReadKey();
                        Console.Clear();
                        MENUADMIN();
                        break;
                    case 3:
                        Console.Clear();
                        CRUD.getInstance().MostrarVentasDelDiaMenu();
                        Console.ReadKey();
                        Console.Clear();
                        MENUADMIN();
                        break;
                    case 4:
                        Console.Clear();
                        menu();
                        return;
                }
            } while (opcion == 4);

        }
        public void menu() {

            int opcion;
            do
            {
                Console.WriteLine("1)"+" "+"---------------------------------ADMIN----------------------------------------");
                Console.WriteLine("2)" + " " + "-----------------------------Cliente-------------------------------------");
                Console.WriteLine("3)" + " " + "-----------------------------Salir-----------------------------------------");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        this.MENUADMIN();
                        break;
                    case 2:
                        Console.Clear();
                        Cliente cliente = LOGUEO();
                        Console.Clear();
                        this.MENUCLIENTE(cliente);
                        break;
                    case 3:
                        return;                   
                }

            } while (opcion==3);
            }       
        }

    }




