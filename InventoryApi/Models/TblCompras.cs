using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    public class TblCompras
    {
        [Key] 
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal CostoTotal { get; set; }
        public string Estatus { get; set; }
        public DateTime Fecha { get; set; }
    }
}
