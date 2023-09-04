using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejercicio1.Models
{
    [Table("Categoria")]
    public class Categoria
    {

        public int Id { get; set; }
        [Column(TypeName = "Varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        #region propiedades de navegacion
        public List<Producto>Productos{ get; set; }

        #endregion
    }
}
