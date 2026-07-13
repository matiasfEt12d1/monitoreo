namespace presentation.domain
{
    public class Servidor : Computadora
    {
        public double MaxTemperaturaTolerada { get; set; } = 70.0; 

        public Servidor(string codigoInventario, string numeroSerie, string so, Laboratorio lab, ModeloPC modelo) 
            : base(codigoInventario, numeroSerie, so, lab, modelo) { }

        public override bool EvaluarEstadoCritico()
        {
            if (_mediciones.Count == 0) return false;
        
            var ultimaMedicion = _mediciones[^1]; 
            return (double)ultimaMedicion.TemperaturaCPU > MaxTemperaturaTolerada || (double)ultimaMedicion.UsoRAM > 90.0;
        }
    }
}