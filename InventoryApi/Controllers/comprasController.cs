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
    public class comprasController : ControllerBase
    {
        private readonly AppDbContext context;
        public comprasController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<comprasController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblCompras.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<comprasController>/5
        [HttpGet("{id}", Name = "GetCompras")]
        public ActionResult Get(int id)
        {
            try
            {
                var compras = context.tblCompras.FirstOrDefault(f => f.Id == id);
                return Ok(compras);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<comprasController>
        [HttpPost]
        public ActionResult Post([FromBody]TblCompras tblCompras)
        {
            try
            {
                context.tblCompras.Add(tblCompras);
                context.SaveChanges();
                return CreatedAtRoute("GetCompras", new { id = tblCompras.Id }, tblCompras);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<comprasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblCompras tblCompras)
        {
            try
            {
                if (tblCompras.Id == id)
                {
                    context.Entry(tblCompras).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCompras", new { id = tblCompras.Id }, tblCompras);
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

        // DELETE api/<comprasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var compras = context.tblCompras.FirstOrDefault(f => f.Id == id);


                if (compras != null)
                {
                    context.tblCompras.Remove(compras);
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
