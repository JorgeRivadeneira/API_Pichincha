using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Pichincha.Models
{
    [Table("Cliente")]
    public class Cliente : Persona
    {
        public int Id_Cliente { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public int Id_Persona { get; set; }
    }
}
