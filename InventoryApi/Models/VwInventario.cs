using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    public class VwInventario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Costo { get; set; }
        public decimal Venta { get; set; }
        public decimal PendientesIngreso { get; set; }
        public decimal Compras { get; set; }
        public decimal TotalCompras { get; set; }
        public decimal Ventas { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal Inventario { get; set; }
    }
}
