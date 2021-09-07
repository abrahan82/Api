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
    public class proveedorController : ControllerBase
    {
        private readonly AppDbContext context;
        public proveedorController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<proveedorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblProveedor.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<proveedorController>/5
        [HttpGet("{id}", Name = "GetProveedor")]
        public ActionResult Get(int id)
        {
            try
            {
                var proveedor = context.tblProveedor.FirstOrDefault(f => f.Id == id);
                return Ok(proveedor);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<proveedorController>
        [HttpPost]
        public ActionResult Post([FromBody] TblProveedor tblProveedor)
        {
            try
            {
                context.tblProveedor.Add(tblProveedor);
                context.SaveChanges();
                return CreatedAtRoute("GetProveedor", new { id = tblProveedor.Id }, tblProveedor);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<proveedorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TblProveedor tblProveedor)
        {
            try
            {
                if (tblProveedor.Id == id)
                {
                    context.Entry(tblProveedor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProveedor", new { id = tblProveedor.Id }, tblProveedor);
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

        // DELETE api/<proveedorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var proveedor = context.tblProveedor.FirstOrDefault(f => f.Id == id);


                if (proveedor != null)
                {
                    context.tblProveedor.Remove(proveedor);
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
