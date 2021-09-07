using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    public class TblClientes
    {
        [Key]
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string Email { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Estatus { get; set; }
    }
}
