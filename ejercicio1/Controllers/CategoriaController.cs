using ejercicio1.Data;
using ejercicio1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ejercicio1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly dbProductoLunesContext context;

        public CategoriaController(dbProductoLunesContext context)
        {
            this.context = context;
        }

        //GET api/Categoria
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return context.Categorias.ToList();
        }

        //GET api/Categoria/1
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(int id)
        {
            return context.Categorias.Find(id);
        }

        //POST api/Categoria
        //Modelo "Categoria" POST--> cuerpo del HTTP
        [HttpPost]
        public ActionResult Post (Categoria categoria)
        {
            //agregar la categoria en memoria
            context.Categorias.Add(categoria);

            //guardo DB
            context.SaveChanges(); //conectarse DB, insert into.... , y desconecta
            return Ok();
        }

        //PUT api/Categoria/id
        [HttpPut("{id}")]
        public ActionResult Put(int id,Categoria categoria) 
        {
            if(id != categoria.Id)
            {
                return BadRequest();
            }
            //EF modificar memoria
            context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }

        //DELETE api/Categoria/id
        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id) 
        {
            var categoria = context.Categorias.Find(id);
            if(categoria == null)
            {
                return NotFound();
            }    
            //EF en Memoria marcar el objeto para eliminar
            context.Categorias.Remove(categoria);
            //aplicar los cambios en BD
            context.SaveChanges();
            return categoria;

        }

    }
}
