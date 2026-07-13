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

                // Llamamos al repositorio que está en la capa 'data'
                List<Computadora> computadoras = Repositorio.ObtenerTodas();

                foreach (var pc in computadoras)
                {
                    // Usamos las entidades y el polimorfismo de la capa 'domain'
                    pc.AgregarMedicion(new Medicion("00:1A:2B:3C:4D:5E", 75.5m, 88.0m));

                    Console.WriteLine($"PC: {pc.CodigoInventario} | Tipo: {pc.GetType().Name}");
                    Console.WriteLine($"¿Crítico?: {(pc.EvaluarEstadoCritico() ? "SI" : "NO")}");
                    Console.WriteLine(new string('-', 30));
                }
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
        }
    }
}