namespace TADHV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dummies",
                c => new
                    {
                        DummyID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DummyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dummies");
        }
    }
}
