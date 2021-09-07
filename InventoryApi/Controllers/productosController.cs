using InventoryApi.Context;
using InventoryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productosController : ControllerBase
    {
        private readonly AppDbContext context;
        public productosController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<productosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblProductos.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<productosController>/5
        [HttpGet("{id}", Name = "GetProductos")]
        public ActionResult Get(int id)
        {
            try
            {
                var compras = context.tblProductos.FirstOrDefault(f => f.Id == id);
                return Ok(compras);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<productosController>
        [HttpPost]
        public ActionResult Post([FromBody] TblProductos tblProductos)
        {
            try
            {
                context.tblProductos.Add(tblProductos);
                context.SaveChanges();
                return CreatedAtRoute("GetProductos", new { id = tblProductos.Id }, tblProductos);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<productosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblProductos tblProductos)
        {
            try
            {
                if (tblProductos.Id == id)
                {
                    context.Entry(tblProductos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProductos", new { id = tblProductos.Id }, tblProductos);
                }
                else
                {
                    return BadRequest("Id enviado no coincide con el cuerpo de envio");
                }



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<productosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var productos = context.tblProductos.FirstOrDefault(f => f.Id == id);


                if (productos != null)
                {
                    context.tblProductos.Remove(productos);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest("No existe registtro");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
