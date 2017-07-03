namespace TimeMachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInteractions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Interactions");
        }
    }
}
