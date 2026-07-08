namespace presentation.domain
{
    public class ModeloPC
    {
        public int IdModelo { get; set; }
        private string _marca = string.Empty;
        private string _modelo = string.Empty;
        private string _especs = string.Empty;
        public int Ram { get; set; }

        public string Marca
        {
            get => _marca;
            set => _marca = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Marca obligatoria.");
        }

        public string Modelo
        {
            get => _modelo;
            set => _modelo = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Modelo obligatorio.");
        }

        public string Especs 
        { 
            get => _especs; 
            set => _especs = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Especificaciones obligatorias."); 
        }

        public ModeloPC(string marca, string modelo, string specs, int ram)
        {
            Marca = marca;
            Modelo = modelo;
            Especs = specs;
            Ram = ram;
        }
    }
}