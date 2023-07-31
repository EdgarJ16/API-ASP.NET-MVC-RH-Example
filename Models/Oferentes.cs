using System.ComponentModel.DataAnnotations;

namespace BackEnd.API.Models
{

    public class Oferentes
    {
        


        /// <summary>
        /// 
        /// </summary>


        [Key]
        [Required]
        [MaxLength(12), MinLength(12)]
        public string ID { get; set; }
        [Required, MinLength(10), MaxLength(60)]
        public string Nombre { get; set; }
        public string Ministerios { get; set; }
        [Required, RegularExpression(".........", ErrorMessage = "El numero debe contener 9 digitos")]
        public int Telefono { get; set; }

        [Required, MinLength(10), MaxLength(60), EmailAddress]
        public string Correo { get; set; }

        [Required, MinLength(10), MaxLength(100)]
        public string Profesion { get; set; }

        [Required, Range(1900, 2004)]
        public int Nacimiento { get; set; }
        public int AñoExp { get; set; }

    

    }
}
