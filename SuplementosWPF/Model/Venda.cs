using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuplementosWPF.Models
{
    [Table("Venda")]
    class Venda
    {
        [Key]
        public int VendaId { get; set; }
        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public List<ItemVenda> Suplementos { get; set; }
        public DateTime DataDaVenda { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        public Venda()
        {
            Cliente = new Cliente();
            Funcionario = new Funcionario();
            Suplementos = new List<ItemVenda>();
            FormaPagamento = new FormaPagamento();
        }
    }
}
