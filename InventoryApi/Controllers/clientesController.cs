using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryApi.Context;
using InventoryApi.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientesController : ControllerBase
    {
        private readonly AppDbContext context;
        public clientesController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<clientesController>
        [HttpGet]
        public ActionResult Get()
        {

            try
            {
                return Ok(context.tblClientes.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<clientesController>/5
        [HttpGet("{id}", Name = "GetClientes")]
        public ActionResult Get(int id)
        {
            try
            {
                var clientes = context.tblClientes.FirstOrDefault(f => f.Id == id);
                return Ok(clientes);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<clientesController>
        [HttpPost]
        public ActionResult Post([FromBody]TblClientes tblClientes )
        {
            try
            {
                context.tblClientes.Add(tblClientes);
                context.SaveChanges();
                return CreatedAtRoute("GetClientes", new { id = tblClientes.Id }, tblClientes);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<clientesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblClientes tblClientes)
        {
            try
            {
                if (tblClientes.Id == id)
                {
                    context.Entry(tblClientes).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetClientes", new { id = tblClientes.Id }, tblClientes);
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

        // DELETE api/<clientesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var clientes = context.tblClientes.FirstOrDefault(f => f.Id == id);


                if (clientes != null)
                {
                    context.tblClientes.Remove(clientes);
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
