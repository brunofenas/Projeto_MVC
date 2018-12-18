namespace Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entidade_Cadastro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cadastro",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                        Temperatura = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cadastro");
        }
    }
}
