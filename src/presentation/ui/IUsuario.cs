using System;
using System.Collections.Generic;
using presentation.data;
using presentation.domain;

namespace presentation.ui;

public static class IUsuario
{
    public static void MenuRegistrarLaboratorio()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR LABORATORIO ===");
        
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        Console.Write("Ubicación: ");
        string ubicacion = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ubicacion))
        {
            Console.WriteLine("Error: Tanto el nombre como la ubicación son obligatorios.");
            return;
        }

        try
        {
            var lab = new Laboratorio(nombre, ubicacion);
            Repositorio.GuardarLaboratorio(lab);
            Console.WriteLine("\nLaboratorio registrado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al guardar el laboratorio: {ex.Message}");
        }
    }

    public static void MenuRegistrarModelo()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR MODELO DE PC ===");
        
        Console.Write("Marca: ");
        string marca = Console.ReadLine() ?? "";
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine() ?? "";
        Console.Write("Especificaciones: ");
        string especs = Console.ReadLine() ?? "";
        Console.Write("Memoria RAM (GB): ");
        
        if (!int.TryParse(Console.ReadLine(), out int ram))
        {
            Console.WriteLine("Entrada de RAM inválida. Debe ser numérica.");
            return;
        }

        if (string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(modelo) || string.IsNullOrWhiteSpace(especs))
        {
            Console.WriteLine("Error: Marca, modelo y especificaciones son obligatorios.");
            return;
        }

        try
        {
            var mod = new ModeloPC(marca, modelo, especs, ram);
            Repositorio.GuardarModelo(mod);
            Console.WriteLine("\nModelo registrado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al guardar el modelo: {ex.Message}");
        }
    }

    public static void MenuRegistrarComputadora()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR COMPUTADORA ===");
        
        Console.Write("Código Inventario: ");
        string codigo = Console.ReadLine() ?? "";
        Console.Write("Número de Serie: ");
        string serie = Console.ReadLine() ?? "";
        Console.Write("Sistema Operativo (ej. Windows, Ubuntu, Linux Server): ");
        string so = Console.ReadLine() ?? "";
        Console.Write("Nombre exacto del Laboratorio: ");
        string nombreLab = Console.ReadLine() ?? "";
        Console.Write("Modelo exacto de la PC: ");
        string modeloPc = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(serie))
        {
            Console.WriteLine("Error: El código de inventario y el número de serie son requeridos por el dominio.");
            return;
        }

        try
        {
            var labAux = new Laboratorio(nombreLab, "Auxiliar");
            var modAux = new ModeloPC("Auxiliar", modeloPc, "Auxiliar", 0);

            Computadora pc = so.Contains("Server", StringComparison.OrdinalIgnoreCase)
                ? new Servidor(codigo, serie, so, labAux, modAux)
                : new ComputadoraEscritorio(codigo, serie, so, labAux, modAux);

            Repositorio.GuardarComputadora(pc);
            Console.WriteLine("\nComputadora registrada exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }

    public static void MenuMostrarInventario()
    {
        Console.Clear();
        Console.WriteLine("=== INVENTARIO DE COMPUTADORAS ===");

        try
        {
            List<Computadora> computadoras = Repositorio.ObtenerTodas();

            if (computadoras.Count == 0)
            {
                Console.WriteLine("No se encontraron equipos registrados.");
                return;
            }

            foreach (var pc in computadoras)
            {
                string tipo = pc is Servidor ? "SERVIDOR" : "ESCRITORIO";
                Console.WriteLine($"├── [{tipo}] Cód: {pc.CodigoInventario} | SO: {pc.SistemaOperativo}");
                Console.WriteLine($"│   ├── Ubicación: Lab {pc.Laboratorio.Nombre} ({pc.Laboratorio.Ubicacion})");
                Console.WriteLine($"└── Hardware: {pc.Modelo.Marca} {pc.Modelo.Modelo} | {pc.Modelo.Ram}GB RAM");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer la base de datos: {ex.Message}");
        }
    }

    public static void MenuRegistrarMedicion()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR MEDICIÓN ===");
        
        Console.Write("Código Inventario de la PC objetivo: ");
        string codigo = Console.ReadLine() ?? "";
        
        Console.Write("Dirección MAC: ");
        string mac = Console.ReadLine() ?? "";
        
        Console.Write("Temperatura CPU (°C): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal temp)) 
        {
            Console.WriteLine("Temperatura inválida.");
            return;
        }
        
        Console.Write("Uso de RAM (%): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal usoRam)) 
        {
            Console.WriteLine("Uso de RAM inválido.");
            return;
        }
        
        Console.Write("Estado de salud (Óptimo/Mantenimiento): ");
        string estadoInput = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(mac))
        {
            Console.WriteLine("Error: La dirección MAC es obligatoria.");
            return;
        }

        try
        {
            var medicion = new Medicion(mac, temp, usoRam);
            
            if (!string.IsNullOrWhiteSpace(estadoInput))
            {
                medicion.Estado = estadoInput;
            }

            Repositorio.GuardarMedicion(medicion, codigo);
            Console.WriteLine("\nMedición guardada correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }
}