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
    public class perfilController : ControllerBase
    {
        private readonly AppDbContext context;
        public perfilController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<perfilController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblPerfil.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<perfilController>/5
        [HttpGet("{id}", Name = "GetPerfil")]
        public ActionResult Get(int id)
        {
            try
            {
                var perfil = context.tblPerfil.FirstOrDefault(f => f.Id == id);
                return Ok(perfil);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<perfilController>
        [HttpPost]
        public ActionResult Post([FromBody]TblPerfil tblPerfil)
        {
            try
            {
                context.tblPerfil.Add(tblPerfil);
                context.SaveChanges();
                return CreatedAtRoute("GetPerfil", new { id = tblPerfil.Id }, tblPerfil);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<perfilController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblPerfil tblPerfil)
        {
            try
            {
                if (tblPerfil.Id == id)
                {
                    context.Entry(tblPerfil).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPerfil", new { id = tblPerfil.Id }, tblPerfil);
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

        // DELETE api/<perfilController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var perfil = context.tblPerfil.FirstOrDefault(f => f.Id == id);


                if (perfil != null)
                {
                    context.tblPerfil.Remove(perfil);
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
