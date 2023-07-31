using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Webclient.Models
{
    public class Titulos
    {

       
   
        [Required]
        public string ID { get; set; }
       

        [Required, MinLength(10), MaxLength(150)]
        public string Grado { get; set; }

        [Required, MinLength(10), MaxLength(60)]
        public string Centro { get; set; }

        [Required, RegularExpression("....")]
        public int AñoAdquirido { get; set; }
        
    }



}
