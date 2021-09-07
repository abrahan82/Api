using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    public class TblUser
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estatus { get; set; }
        public int Perfil { get; set; }
    }
}
