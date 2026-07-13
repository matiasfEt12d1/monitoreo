namespace presentation.domain
{
    public abstract class Computadora : IComputadora
    {
        public int IdPC { get; set; }
        public string CodigoInventario { get; set; }
        public string NumeroSerie { get; set; }
        public string SistemaOperativo { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public ModeloPC Modelo { get; set; }
    
        protected List<Medicion> _mediciones = new List<Medicion>();
        public List<Medicion> Mediciones => _mediciones;

        protected Computadora(string codigoInventario, string numeroSerie, string so, Laboratorio lab, ModeloPC modelo)
        {
            if (string.IsNullOrWhiteSpace(codigoInventario)) throw new ArgumentException("Código de inventario requerido.");
            if (string.IsNullOrWhiteSpace(numeroSerie)) throw new ArgumentException("Número de serie requerido.");
        
            CodigoInventario = codigoInventario;
            NumeroSerie = numeroSerie;
            SistemaOperativo = so;
            Laboratorio = lab;
            Modelo = modelo;
        }

        public void AgregarMedicion(Medicion nuevaMedicion)
        {
            if (nuevaMedicion != null) _mediciones.Add(nuevaMedicion);
        }

        public abstract bool EvaluarEstadoCritico();
    }
}
