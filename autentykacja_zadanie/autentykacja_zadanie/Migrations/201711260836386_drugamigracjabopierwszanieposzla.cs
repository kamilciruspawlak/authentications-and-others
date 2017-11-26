namespace autentykacja_zadanie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drugamigracjabopierwszanieposzla : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreate = c.DateTime(nullable: false),
                        DateMod = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Name = c.String(),
                        Model = c.String(),
                        Type = c.String(),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Engines");
        }
    }
}
