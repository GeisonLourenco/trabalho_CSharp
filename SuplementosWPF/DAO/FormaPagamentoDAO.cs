using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuplementosWPF.Model;

namespace SuplementosWPF.DAO
{
    class FormaPagamentoDAO
    {
        private static List<FormaPagamento> formasPagamento = new List<FormaPagamento>();
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarFormaPagamento(FormaPagamento forma)
        {
            try
            {
                ctx.FormasDePagamento.Add(forma);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static List<FormaPagamento> ListaFormasPagamento()
        {
            return ctx.FormasDePagamento.ToList();
        }

        public static FormaPagamento BuscarFormaPagamento(FormaPagamento forma)
        {
            return ctx.FormasDePagamento.FirstOrDefault(x => x.tipo.Equals(forma.tipo));
        }
    }

}