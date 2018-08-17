namespace AspImpactaBiblioteca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermiteNuloPagamentoEmEmprestimo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Emprestimo", new[] { "PagamentoId" });
            AlterColumn("dbo.Emprestimo", "PagamentoId", c => c.Int());
            CreateIndex("dbo.Emprestimo", "PagamentoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Emprestimo", new[] { "PagamentoId" });
            AlterColumn("dbo.Emprestimo", "PagamentoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Emprestimo", "PagamentoId");
        }
    }
}
