namespace SuplementosWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                {
                    ClienteId = c.Int(nullable: false, identity: true),
                    Nome = c.String(),
                    CPF = c.String(),
                })
                .PrimaryKey(t => t.ClienteId);

            CreateTable(
                "dbo.FormaPagamento",
                c => new
                {
                    FormaPagamentoId = c.Int(nullable: false, identity: true),
                    tipo = c.String(),
                })
                .PrimaryKey(t => t.FormaPagamentoId);

            CreateTable(
                "dbo.ItemVenda",
                c => new
                {
                    ItemVendaId = c.Int(nullable: false, identity: true),
                    Quantidade = c.Int(nullable: false),
                    PrecoUnitario = c.Double(nullable: false),
                    Suplemento_SuplementoId = c.Int(),
                    Venda_VendaId = c.Int(),
                })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Suplemento", t => t.Suplemento_SuplementoId)
                .ForeignKey("dbo.Venda", t => t.Venda_VendaId)
                .Index(t => t.Suplemento_SuplementoId)
                .Index(t => t.Venda_VendaId);

            CreateTable(
                "dbo.Suplemento",
                c => new
                {
                    SuplementoId = c.Int(nullable: false, identity: true),
                    Nome = c.String(),
                    Preco = c.Double(nullable: false),
                    Markup = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.SuplementoId);

            CreateTable(
                "dbo.Venda",
                c => new
                {
                    VendaId = c.Int(nullable: false, identity: true),
                    DataDaVenda = c.DateTime(nullable: false),
                    Cliente_ClienteId = c.Int(),
                    FormaPagamento_FormaPagamentoId = c.Int(),
                    Funcionario_FuncionarioId = c.Int(),
                })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteId)
                .ForeignKey("dbo.FormaPagamento", t => t.FormaPagamento_FormaPagamentoId)
                .ForeignKey("dbo.Vendedor", t => t.Funcionario_FuncionarioId)
                .Index(t => t.Cliente_ClienteId)
                .Index(t => t.FormaPagamento_FormaPagamentoId)
                .Index(t => t.Funcionario_FuncionarioId);

            CreateTable(
                "dbo.Funcionario",
                c => new
                {
                    FuncionarioId = c.Int(nullable: false, identity: true),
                    Nome = c.String(),
                    CPF = c.String(),
                    Comissao = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.FuncionarioId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Venda", "Funcionario_FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.ItemVenda", "Venda_VendaId", "dbo.Venda");
            DropForeignKey("dbo.Venda", "FormaPagamento_FormaPagamentoId", "dbo.FormaPagamento");
            DropForeignKey("dbo.Venda", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ItemVenda", "Suplemento_SuplementoId", "dbo.Suplemento");
            DropIndex("dbo.Venda", new[] { "Funcionario_FuncionarioId" });
            DropIndex("dbo.Venda", new[] { "FormaPagamento_FormaPagamentoId" });
            DropIndex("dbo.Venda", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.ItemVenda", new[] { "Venda_VendaId" });
            DropIndex("dbo.ItemVenda", new[] { "Suplemento_SuplementoId" });
            DropTable("dbo.Funcionarior");
            DropTable("dbo.Venda");
            DropTable("dbo.Suplemento");
            DropTable("dbo.ItemVenda");
            DropTable("dbo.FormaPagamento");
            DropTable("dbo.Clientes");
        }
    }
}
