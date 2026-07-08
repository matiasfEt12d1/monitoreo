namespace presentation.domain
{
    public class ComputadoraEscritorio : Computadora
    {
        public ComputadoraEscritorio(string codigoInventario, string numeroSerie, string so, Laboratorio lab, ModeloPC modelo) 
            : base(codigoInventario, numeroSerie, so, lab, modelo) { }

        public override bool EvaluarEstadoCritico()
        {
            if (_mediciones.Count == 0) return false;

            var ultimaMedicion = _mediciones[^1];
            return (double)ultimaMedicion.TemperaturaCPU > 85.0 || (double)ultimaMedicion.UsoRAM > 95.0;
        }
    }
}