using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Models
{
    public class TblPerfil
    {
        [Key]
        public int Id { get; set; }
        public string Catalogo { get; set; }
        public string Valor { get; set; }
        public bool Status{ get; set; }
    }
}
