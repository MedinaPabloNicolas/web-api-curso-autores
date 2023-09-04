using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejercicio2.Models
{
    [Table("Autor")]
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string Nombre { get; set; }

        #region propiedades de navegacion
        public List<Libro> Libros { get; set; }

        #endregion
    }
}
