using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuplementosWPF.Model;

namespace SuplementosWPF.DAO
{
    /*primeira vez - install-package entityframework          Instala EntityFramework
    primeira vez - enable-migrations
    add-migration
    update-database
       */
    class Context : DbContext
        {
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<FormaPagamento> FormasDePagamento { get; set; }
            public DbSet<ItemVenda> ItensVenda { get; set; }
            public DbSet<Suplemento> Suplementos { get; set; }
            public DbSet<Venda> Vendas { get; set; }
            public DbSet<Funcionario> Funcionarios { get; set; }

        }
    }

