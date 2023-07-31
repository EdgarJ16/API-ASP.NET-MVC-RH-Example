using System.ComponentModel.DataAnnotations;

namespace BackEnd.API.Models
{

    public class Concurso
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public string Estado { get; set; }

        public string Nombre { get; set; }
    }
}
