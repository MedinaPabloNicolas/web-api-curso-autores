using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ejercicio2.Models
{
    [Table("Libro")]
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string Titulo { get; set; }
        public int AutorId { get; set; }

        #region propiedades de navegacion
        public Autor Autor { get; set; }
        #endregion
    }
}
