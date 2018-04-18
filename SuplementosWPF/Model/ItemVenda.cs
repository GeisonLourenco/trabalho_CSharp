using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuplementosWPF.Models
{
    [Table("ItemVenda")]
    class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }
        public Suplemento Suplemento { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
    }
}
