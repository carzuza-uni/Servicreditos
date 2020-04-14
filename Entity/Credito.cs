using System;

namespace Entity
{
    public class Credito
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public decimal CapitalInicial { get; set; }
        public int TasaInteres { get; set; }
        public int TiempoDuracion { get; set; }
        public decimal TotalPagar { get; set; }

        public decimal CalcularTasaInteres(){
            return this.TasaInteres / 100;
        }

        public decimal CalcularTotalPagar(){
            if(this.CapitalInicial > 0 && this.TiempoDuracion > 0){
                double x = (double)(1 + this.CalcularTasaInteres());
                double y = (double)(this.TiempoDuracion);
                this.TotalPagar = (decimal)( (double)(this.CapitalInicial) * (Math.Pow( x , y )));
                return this.TotalPagar;
            }
            return 0;
        }

    }
}
