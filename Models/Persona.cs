using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Pichincha.Models
{
    //[NotMapped]
    public class Persona
    {
        [Key]
        public int Id_Persona { get; set; }
        public String Nombre { get; set; }
        public String Genero { get; set; }
        public int Edad { get; set; }
        public String Identificacion { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
    }
}
