namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeMae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoas", "NomeMae", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoas", "NomeMae");
        }
    }
}
