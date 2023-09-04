using ejercicio2.Models;
using Microsoft.EntityFrameworkCore;

namespace ejercicio2.Data
{
    public class dbAutoresContext:DbContext
    {
        public dbAutoresContext(DbContextOptions<dbAutoresContext> options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}
