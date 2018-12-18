namespace Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Campo_CEP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cadastro", "CEP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cadastro", "CEP");
        }
    }
}
