using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    public class TblProductos
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int Stock { get; set; }
        public decimal Costo { get; set; }
        public decimal Venta { get; set; }
        public string Imagen { get; set; }
        public bool Status { get; set; }
    }
}
