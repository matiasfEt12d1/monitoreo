namespace presentation.domain
{
    public class Medicion
    {
        public int IdMedicion { get; set; }
        public string MacAddress { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaArreglo { get; set; }
        public DateTime? FechaDesecho { get; set; }
        public string Estado { get; set; } = "Operativo";
    
        public decimal TemperaturaCPU { get; set; }
        public decimal UsoRAM { get; set; }

        public Medicion(string mac, decimal tempCpu, decimal usoRam)
        {
            if (string.IsNullOrWhiteSpace(mac)) throw new ArgumentException("Mac Address obligatoria.");
            MacAddress = mac;
            TemperaturaCPU = tempCpu;
            UsoRAM = usoRam;
            FechaIngreso = DateTime.Now;
        }
    }
}