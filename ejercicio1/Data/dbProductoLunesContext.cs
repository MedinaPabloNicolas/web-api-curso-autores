using ejercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace ejercicio1.Data
{
    public class dbProductoLunesContext:DbContext
    {
        //tiene que estar en el constructor con parametro
        public dbProductoLunesContext(DbContextOptions<dbProductoLunesContext>options) : base(options) { }

        //Propiedades DBSet

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
