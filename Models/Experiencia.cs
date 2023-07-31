using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Webclient.Models
{
    public class Experiencia
    {
        [Key]
        [Required]
        public string ID { get; set; }
       
     

        [Required, MinLength(10), MaxLength(150)]
        public string Empresa { get; set; }

        [Required, RegularExpression("....")]
        public int AñoInicio { get; set; }

        [Required, RegularExpression("....")]
        public int AñoFIn { get; set; }
    }
}
