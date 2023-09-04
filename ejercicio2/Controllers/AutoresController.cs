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
    public class AutoresController : ControllerBase
    {
        private readonly dbAutoresContext context;

        public AutoresController(dbAutoresContext context)
        {
            this.context = context;
        }

        //GET api/Autores
        [HttpGet]
        public IEnumerable<Autor> Get()
        {
            return context.Autores.ToList();
        }

        //GET api/Autores/1
        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id)
        {
            return context.Autores.Find(id);
        }

        //POST api/Autores
        //Modelo "Autor" POST--> cuerpo del HTTP
        [HttpPost]
        public ActionResult Post(Autor autor)
        {
            //agregar la categoria en memoria
            context.Autores.Add(autor);

            //guardo DB
            context.SaveChanges(); //conectarse DB, insert into.... , y desconecta
            return Ok();
        }

        //PUT api/Autores/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }
            //EF modificar memoria
            context.Entry(autor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }

        //DELETE api/Autores/id
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autores.Find(id);
            if (autor == null)
            {
                return NotFound();
            }
            //EF en Memoria marcar el objeto para eliminar
            context.Autores.Remove(autor);
            //aplicar los cambios en BD
            context.SaveChanges();
            return autor;

        }

    }
}
