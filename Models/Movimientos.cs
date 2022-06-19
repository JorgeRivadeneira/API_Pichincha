using System.ComponentModel.DataAnnotations;

namespace API_Pichincha.Models
{
    public class Movimientos
    {
        [Key]
        public int Id_Movimiento { get; set; }
        public DateTime Fecha { get; set; }
        public String Tipo_Movimiento { get; set; }
        public double Valor { get; set; }
        public double Saldo { get; set; }
        public int Id_Cuenta { get; set; }
        public double Saldo_Inicial { get; set; }

    }
}
