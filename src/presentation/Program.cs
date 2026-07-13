using presentation.domain;
using presentation.data;
using System;
using System.Collections.Generic;

namespace presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE MONITOREO ===");
        
            try
            {
                // Creamos la base de datos y las tablas si no existen
                Repositorio.InicializarBaseDeDatos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error principal: {ex.Message}");
                
                // Inspeccionamos la excepción interna para ver el error real
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"\nCausa real (InnerException): {ex.InnerException.Message}");
                    Console.WriteLine($"Rastreo (StackTrace):\n{ex.InnerException.StackTrace}");
                }
            }
            finally
            {
                // Esto mantendrá la consola abierta para que leas el error
                Console.WriteLine("\nPresiona Enter para salir...");
                Console.ReadLine();
            }
        }
    }
}