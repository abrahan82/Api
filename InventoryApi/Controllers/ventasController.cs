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
    public class ventasController : ControllerBase
    {
        private readonly AppDbContext context;
        public ventasController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ventasController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblVentas.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ventasController>/5
        [HttpGet("{id}", Name = "GetVentas")]
        public ActionResult Get(int id)
        {
            try
            {
                var ventas = context.tblVentas.FirstOrDefault(f => f.Id == id);
                return Ok(ventas);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ventasController>
        [HttpPost]
        public ActionResult Post([FromBody]TblVentas Ventas)
        {
            try
            {
                context.tblVentas.Add(Ventas);
                context.SaveChanges();
                return CreatedAtRoute("GetVentas", new { id = Ventas.Id }, Ventas);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ventasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblVentas tblVentas)
        {
            try
            {
                if (tblVentas.Id == id)
                {
                    context.Entry(tblVentas).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetVentas", new { id = tblVentas.Id }, tblVentas);
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

        // DELETE api/<ventasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var ventas = context.tblVentas.FirstOrDefault(f => f.Id == id);


                if (ventas != null)
                {
                    context.tblVentas.Remove(ventas);
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
