namespace AspImpactaBiblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        TotalPaginas = c.Int(nullable: false),
                        Descricao = c.String(),
                        Quantidade = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autor", t => t.AutorId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .Index(t => t.CategoriaId)
                .Index(t => t.AutorId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        Email = c.String(),
                        valorPagar = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emprestimo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        DataEmprestimo = c.DateTime(nullable: false),
                        DataDevolucao = c.DateTime(nullable: false),
                        LivroId = c.Int(nullable: false),
                        Devolvido = c.Boolean(nullable: false),
                        PagamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Livro", t => t.LivroId)
                .ForeignKey("dbo.Pagamento", t => t.PagamentoId)
                .Index(t => t.ClienteId)
                .Index(t => t.LivroId)
                .Index(t => t.PagamentoId);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        ValorPago = c.Double(nullable: false),
                        FormaPagamentoId = c.Int(nullable: false),
                        DataPagamento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.FormaPagamento", t => t.FormaPagamentoId)
                .Index(t => t.ClienteId)
                .Index(t => t.FormaPagamentoId);
            
            CreateTable(
                "dbo.FormaPagamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emprestimo", "PagamentoId", "dbo.Pagamento");
            DropForeignKey("dbo.Pagamento", "FormaPagamentoId", "dbo.FormaPagamento");
            DropForeignKey("dbo.Pagamento", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Emprestimo", "LivroId", "dbo.Livro");
            DropForeignKey("dbo.Emprestimo", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Livro", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Livro", "AutorId", "dbo.Autor");
            DropIndex("dbo.Pagamento", new[] { "FormaPagamentoId" });
            DropIndex("dbo.Pagamento", new[] { "ClienteId" });
            DropIndex("dbo.Emprestimo", new[] { "PagamentoId" });
            DropIndex("dbo.Emprestimo", new[] { "LivroId" });
            DropIndex("dbo.Emprestimo", new[] { "ClienteId" });
            DropIndex("dbo.Livro", new[] { "AutorId" });
            DropIndex("dbo.Livro", new[] { "CategoriaId" });
            DropTable("dbo.FormaPagamento");
            DropTable("dbo.Pagamento");
            DropTable("dbo.Emprestimo");
            DropTable("dbo.Cliente");
            DropTable("dbo.Categoria");
            DropTable("dbo.Livro");
            DropTable("dbo.Autor");
        }
    }
}
