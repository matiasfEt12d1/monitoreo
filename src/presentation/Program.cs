using presentation.domain;
using presentation.data;
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
                string entrada = Console.ReadLine().ToLower();
                
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