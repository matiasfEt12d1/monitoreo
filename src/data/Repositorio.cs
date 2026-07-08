using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using Dapper; 
using presentation.domain; // Interconecta las carpetas del mismo proyecto

namespace presentation.data;

public static class Repositorio
{
    private static readonly string connectionString;

    static Repositorio()
    {
        var configuration = new ConfigurationBuilder()
            // Cambio clave aquí: AppContext.BaseDirectory garantiza que busque junto al ejecutable
            .SetBasePath(AppContext.BaseDirectory) 
            .AddJsonFile("appsettingsExample.json", optional: false, reloadOnChange: true)
            .Build();

        connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new InvalidOperationException("No se encontró la conexión 'DefaultConnection'.");
    }

    public static IDbConnection GetConnection() => new MySqlConnection(connectionString);

    public static void GuardarLaboratorio(Laboratorio lab)
    {
        using var conn = GetConnection();
        string sql = "INSERT INTO Laboratorio (nombre, ubicacion) VALUES (@Nombre, @Ubicacion)";
        conn.Execute(sql, lab);
    }

    public static void GuardarModelo(ModeloPC mod)
    {
        using var conn = GetConnection();
        string sql = "INSERT INTO ModelosPC (modelo, marca, especs, ram) VALUES (@Modelo, @Marca, @Especs, @Ram)";
        conn.Execute(sql, mod);
    }

    public static void GuardarComputadora(Computadora pc)
    {
        using var conn = GetConnection();
        
        int? idLab = conn.QueryFirstOrDefault<int?>("SELECT id_laboratorio FROM Laboratorio WHERE nombre = @Nombre LIMIT 1", pc.Laboratorio);
        int? idMod = conn.QueryFirstOrDefault<int?>("SELECT idModelo FROM ModelosPC WHERE modelo = @Modelo LIMIT 1", pc.Modelo);

        if (!idLab.HasValue) throw new Exception("Laboratorio no encontrado.");
        if (!idMod.HasValue) throw new Exception("Modelo no encontrado.");

        string sql = @"INSERT INTO Computadoras (codigoInventario, numero_serie, sistemaOperativo, id_laboratorio, idModelo) 
                       VALUES (@CodigoInventario, @NumeroSerie, @SistemaOperativo, @idLab, @idMod)";

        conn.Execute(sql, new { 
            pc.CodigoInventario, 
            pc.NumeroSerie, 
            pc.SistemaOperativo, 
            idLab, 
            idMod 
        });
    }

    public static List<Computadora> ObtenerTodas()
    {
        var lista = new List<Computadora>();
        using var conn = GetConnection();

        string sql = @"SELECT c.codigoInventario, c.sistemaOperativo, c.numero_serie,
                              l.nombre AS Nombre, l.ubicacion AS Ubicacion, 
                              m.marca AS Marca, m.modelo AS Modelo, m.especs AS Especs, m.ram AS Ram
                       FROM Computadoras c
                       JOIN Laboratorio l ON c.id_laboratorio = l.id_laboratorio
                       JOIN ModelosPC m ON c.idModelo = m.idModelo";

        var resultadoRaw = conn.Query<dynamic>(sql);

        foreach (var row in resultadoRaw)
        {
            var lab = new Laboratorio((string)row.Nombre, (string)row.Ubicacion);
            var mod = new ModeloPC((string)row.Marca, (string)row.Modelo, (string)row.Especs, (int)row.Ram);
            
            string so = (string)row.sistemaOperativo;
            string codigo = (string)row.codigoInventario;
            string serie = (string)row.numero_serie;

            Computadora pc;
            // Si el SO contiene "Server", instanciamos un Servidor; si no, una de Escritorio
            if (so.Contains("Server", StringComparison.OrdinalIgnoreCase))
            {
                pc = new Servidor(codigo, serie, so, lab, mod);
            }
            else
            {
                pc = new ComputadoraEscritorio(codigo, serie, so, lab, mod);
            }

            lista.Add(pc);
        }

        return lista;
    }

    public static void GuardarMedicion(Medicion m, string codigoInventario)
    {
        using var conn = GetConnection();

        int? idPC = conn.QueryFirstOrDefault<int?>("SELECT idPC FROM Computadoras WHERE codigoInventario = @codigoInventario LIMIT 1", new { codigoInventario });
        if (!idPC.HasValue) throw new Exception($"No se encontró la PC con código de inventario: {codigoInventario}");

        string sql = @"INSERT INTO Mediciones (idPC, temperaturaCPU, usoRAM, fechaIngreso, estado, macAddress) 
                       VALUES (@idPC, @TemperaturaCPU, @UsoRAM, @FechaIngreso, @Estado, @MacAddress)";

        conn.Execute(sql, new { 
            idPC, 
            m.TemperaturaCPU, 
            m.UsoRAM, 
            m.FechaIngreso, 
            m.Estado,
            m.MacAddress
        });
    }
}