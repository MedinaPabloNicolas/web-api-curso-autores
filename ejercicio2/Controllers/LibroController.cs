using ejercicio2.Data;
using ejercicio2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ejercicio2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly dbAutoresContext context;

        public LibroController(dbAutoresContext context)
        {
            this.context = context;
        }

        //GET api/Libro
        [HttpGet]
        public IEnumerable<Libro> Get()
        {
            return context.Libros.ToList();
        }

        //GET api/Libro/1
        [HttpGet("{id}")]
        public ActionResult<Libro> GetById(int id)
        {
            return context.Libros.Find(id);
        }

        //POST api/Libro
        //Modelo "Autor" POST--> cuerpo del HTTP
        [HttpPost]
        public ActionResult Post(Libro libro)
        {
            //agregar la categoria en memoria
            context.Libros.Add(libro);

            //guardo DB
            context.SaveChanges(); //conectarse DB, insert into.... , y desconecta
            return Ok();
        }

        //PUT api/Libro/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }
            //EF modificar memoria
            context.Entry(libro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }

        //DELETE api/Libro/id
        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = context.Libros.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            //EF en Memoria marcar el objeto para eliminar
            context.Libros.Remove(libro);
            //aplicar los cambios en BD
            context.SaveChanges();
            return libro;

        }

    }
}
