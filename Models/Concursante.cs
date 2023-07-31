using System.ComponentModel.DataAnnotations;

namespace BackEnd.API.Models
{
    public class Concursante
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Nombre { get; set; }


        [Required, Range(1, 100)]
        public int NotaPPsic { get; set; }


        [Required, Range(1, 100)]
        public int NotaPEnt { get; set; }

        [Required, Range(1, 100)]
        public int NotaPTec { get; set; }

   

        
        //METODOS DE CLASE 


       
    }
}
