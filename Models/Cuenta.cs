
using System.ComponentModel.DataAnnotations;

namespace API_Pichincha.Models
{
    public class Cuenta
    {
        [Key]
        public int Id_Cuenta { get; set; }
        public string Nro_Cuenta { get; set; }
        public string Tipo_Cuenta { get; set; }
        public double Saldo_Inicial { get; set; }
        public double Saldo_Disponible { get; set; }
        public bool Estado { get; set; }
        public int Id_Cliente { get; set; }
    }
}
