using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuplementosWPF.Models
{
    [Table("FormaPagamento")]
    class FormaPagamento
    {
        [Key]
        public int FormaPagamentoId { get; set; }
        public string tipo { get; set; }

    }
}
