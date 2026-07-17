using presentation.domain;
using presentation.data;
using presentation.ui;
using System;
using System.Threading;

namespace presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------- MONITOREO ------------");
            Console.WriteLine("---------------------------------");

            bool repetir;

            do
            {
                try
                {
                    Repositorio.InicializarBaseDeDatos();

                    Console.WriteLine("\nIniciando la aplicación...");
                    Thread.Sleep(1000);
                    Console.WriteLine();

                    Console.WriteLine("1. Registrar Laboratorio");
                    Console.WriteLine("2. Registrar Modelo de PC");
                    Console.WriteLine("3. Registrar Computadora");
                    Console.WriteLine("4. Ver Inventario Completo");
                    Console.WriteLine("5. Cargar Medición de Rendimiento");
                    Console.WriteLine();
                    
                    Console.Write("Seleccione una opción: ");

                    string seleccion = Console.ReadLine() ?? "";

                    switch (seleccion)
                    {
                        case "1": 
                            IUsuario.MenuRegistrarLaboratorio(); 
                            break;
                        case "2": 
                            IUsuario.MenuRegistrarModelo(); 
                            break;
                        case "3": 
                            IUsuario.MenuRegistrarComputadora(); 
                            break;
                        case "4": 
                            IUsuario.MenuMostrarInventario(); 
                            break;
                        case "5": 
                            IUsuario.MenuRegistrarMedicion(); 
                            break;
                        default: 
                            Console.WriteLine("\nOpción no válida."); 
                            break;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error principal: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Causa real: {ex.InnerException.Message}");
                    }
                }

                Console.WriteLine("\n¿Quieres realizar otra ejecución? (s/n)");
                string entrada = Console.ReadLine()!.ToLower();
                
                repetir = (entrada == "s");

                if (!repetir)
                {
                    Console.WriteLine("Saliendo de la aplicación...");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.Clear();
                }

            } while (repetir);
        }
    }
}