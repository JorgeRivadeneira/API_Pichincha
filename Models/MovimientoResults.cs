namespace API_Pichincha.Models
{
    public class MovimientoResults
    {
        public DateTime Fecha { get; set; }
        public String Cliente { get; set; }
        public String Nro_Cuenta { get; set; }
        public String Tipo { get; set; }
        public Double Saldo_Inicial { get; set; }
        public Double Monto { get; set; }
        public Double Saldo_Disponible { get; set; }
        public bool Estado { get; set; }
        public String Tipo_Transaccion { get; set; }
    }
}
