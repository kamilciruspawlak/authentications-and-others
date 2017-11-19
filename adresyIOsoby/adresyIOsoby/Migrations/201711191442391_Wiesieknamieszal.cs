namespace adresyIOsoby.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wiesieknamieszal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "AdressId", "dbo.Adresses");
            DropIndex("dbo.People", new[] { "AdressId" });
            AlterColumn("dbo.People", "AdressId", c => c.Int());
            CreateIndex("dbo.People", "AdressId");
            AddForeignKey("dbo.People", "AdressId", "dbo.Adresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "AdressId", "dbo.Adresses");
            DropIndex("dbo.People", new[] { "AdressId" });
            AlterColumn("dbo.People", "AdressId", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "AdressId");
            AddForeignKey("dbo.People", "AdressId", "dbo.Adresses", "Id", cascadeDelete: true);
        }
    }
}
