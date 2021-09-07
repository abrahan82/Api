using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    public class TblConfiguracion
    {
        [Key]
        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Logo { get; set; }
        public string Direccion { get; set; }
        public int TipoId { get; set; }
        public string Estatus { get; set; }
    }
}
