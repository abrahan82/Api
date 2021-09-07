using InventoryApi.Context;
using InventoryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class inventarioController : ControllerBase
    {
        private readonly AppDbContext context;
        public inventarioController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<inventarioController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.vwInventario.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<inventarioController>/5
        [HttpGet("{id}", Name = "GetInventario")]
        public ActionResult Get(int id)
        {
            try
            {
                var inventario = context.vwInventario.FirstOrDefault(f => f.Id == id);
                return Ok(inventario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
