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
    public class configuracionController : ControllerBase
    {
        private readonly AppDbContext context;
        public configuracionController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<configuracionController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblConfiguracion.ToList());

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<configuracionController>/5
        [HttpGet("{id}", Name ="GetConfiguracion")]
        public ActionResult Get(int id)
        {
            try
            {
                var configuraciones = context.tblConfiguracion.FirstOrDefault(f => f.Id == id);
                return Ok(configuraciones);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<configuracionController>
        [HttpPost]
        public ActionResult Post([FromBody]TblConfiguracion Configuracion)
        {
            try
            {
                context.tblConfiguracion.Add(Configuracion);
                context.SaveChanges();
                return CreatedAtRoute("GetConfiguracion", new { id=Configuracion.Id }, Configuracion);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<configuracionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblConfiguracion tblConfiguracion)
        {
            try
            {
                if(tblConfiguracion.Id == id)
                {
                    context.Entry(tblConfiguracion).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetConfiguracion", new { id = tblConfiguracion.Id }, tblConfiguracion);
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

        // DELETE api/<configuracionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var configuraciones = context.tblConfiguracion.FirstOrDefault(f => f.Id == id);
               

                if (configuraciones != null)
                {
                    context.tblConfiguracion.Remove(configuraciones);
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
