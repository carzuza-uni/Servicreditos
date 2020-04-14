using Entity;

namespace webServicreditos.Models
{
    public class CreditoInputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public decimal CapitalInicial { get; set; }
        public int TasaInteres { get; set; }
        public int TiempoDuracion { get; set; }
    }

    public class CreditoViewModel : CreditoInputModel
    {
        public CreditoViewModel()
        {

        }
        public CreditoViewModel(Credito credito)
        {
            Identificacion = credito.Identificacion;
            Nombre = credito.Nombre;
            CapitalInicial = credito.CapitalInicial;
            TasaInteres = credito.TasaInteres;
            TiempoDuracion = credito.TiempoDuracion;
        }
    }
}