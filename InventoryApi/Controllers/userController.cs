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
    public class userController : ControllerBase
    {
        private readonly AppDbContext context;
        public userController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<userController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblUser.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<userController>/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var user = context.tblUser.FirstOrDefault(f => f.Id == id);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{email}/{password}")]
        public ActionResult Get(string email, string password)
        {
            try
            {
                var user = context.tblUser.FirstOrDefault(f => f.User == email && f.Password == password );
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Error en contraseña y usuario");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // POST api/<userController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]TblUser tblUser)
        {
            try
            {
                context.tblUser.Add(tblUser);
                context.SaveChanges();
                return CreatedAtRoute("GetUser", new { id = tblUser.Id }, tblUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TblUser tblUser)
        {
            try
            {
                if (tblUser.Id == id)
                {
                    context.Entry(tblUser).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetUser", new { id = tblUser.Id }, tblUser);
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

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var user = context.tblUser.FirstOrDefault(f => f.Id == id);


                if (user != null)
                {
                    context.tblUser.Remove(user);
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
