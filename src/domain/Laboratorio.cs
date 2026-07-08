namespace presentation.domain
{
    public class Laboratorio
    {
        public int IdLaboratorio { get; set; }
        private string _nombre = string.Empty;
        private string _ubicacion = string.Empty;
        private List<Computadora> _computadoras = new List<Computadora>();

        public string Nombre
        {
            get => _nombre;
            set => _nombre = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Nombre no válido.");
        }

        public string Ubicacion
        {
            get => _ubicacion;
            set => _ubicacion = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Ubicación no válida.");
        }

        public List<Computadora> Computadoras => _computadoras;

        public Laboratorio(string nombre, string ubicacion)
        {
            Nombre = nombre;
            Ubicacion = ubicacion;
        }

        public void AgregarComputadora(Computadora pc) => _computadoras.Add(pc);
    }
}