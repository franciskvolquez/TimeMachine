namespace TimeMachine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentToInteraction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interactions", "Comment", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Interactions", "Comment");
        }
    }
}
