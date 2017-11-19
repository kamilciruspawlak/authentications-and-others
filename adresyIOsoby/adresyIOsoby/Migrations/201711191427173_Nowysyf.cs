namespace adresyIOsoby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nowysyf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "AdressId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "AdressId");
            AddForeignKey("dbo.People", "AdressId", "dbo.Adresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "AdressId", "dbo.Adresses");
            DropIndex("dbo.People", new[] { "AdressId" });
            DropColumn("dbo.People", "AdressId");
        }
    }
}
