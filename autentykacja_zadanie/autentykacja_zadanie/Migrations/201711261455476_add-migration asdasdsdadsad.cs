namespace autentykacja_zadanie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationasdasdsdadsad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Performances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Performances");
        }
    }
}
