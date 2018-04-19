using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuplementosWPF.Model;

namespace SuplementosWPF.DAO
{
    class VendaDAO
    {

        private static List<Venda> vendas = new List<Venda>();
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarVenda(Venda venda)
        {
            try
            {
                ctx.Vendas.Add(venda);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static List<Venda> RetornarLista()
        {
            return ctx.Vendas.ToList();
        }

        public static List<Venda> BuscarVendasPorCliente(Cliente cliente)
        {
            return ctx.Vendas.Where(x => x.Cliente.Nome.Equals(cliente.Nome)).ToList();
        }

        public static List<Venda> BuscarVendasPorFormaPagamento(FormaPagamento forma)
        {
            return ctx.Vendas.Where(x => x.FormaPagamento.tipo.Equals(forma.tipo)).ToList();
        }
    }
}
