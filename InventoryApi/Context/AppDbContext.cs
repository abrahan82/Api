using InventoryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Context
{
    public class AppDbContext : DbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<TblConfiguracion> tblConfiguracion { get; set; }
        
        public DbSet<TblClientes> tblClientes { get; set; }
        public DbSet<TblCompras> tblCompras { get; set; }
        public DbSet<TblPerfil> tblPerfil { get; set; }
        public DbSet<TblProductos> tblProductos { get; set; }
        public DbSet<TblProveedor> tblProveedor { get; set; }
        public DbSet<TblUser> tblUser { get; set; }
        public DbSet<TblVentas> tblVentas { get; set; }
        public DbSet<VwInventario> vwInventario { get; set; }



    }
}
