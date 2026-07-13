namespace presentation.domain
{
    public interface IComputadora
    {
        int IdPC { get; set; }
        string CodigoInventario { get; set; }
        string NumeroSerie { get; set; }
        string SistemaOperativo { get; set; }
        Laboratorio Laboratorio { get; set; }
        ModeloPC Modelo { get; set; }
        List<Medicion> Mediciones { get; }

        void AgregarMedicion(Medicion nuevaMedicion);
        bool EvaluarEstadoCritico();
    }
}
