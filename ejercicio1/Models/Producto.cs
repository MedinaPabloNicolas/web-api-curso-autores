using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejercicio1.Models
{
    [Table("Producto")]
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="Varchar(50)")]
        public string Nombre { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public decimal Precio { get; set;}
        [Column(TypeName = "Varchar(50)")]
        public string color { get; set; }

        public int CategoriaId { get; set; }

        #region propiedades de navegacion
        public Categoria Categoria { get; set;}
        #endregion
    }
}
