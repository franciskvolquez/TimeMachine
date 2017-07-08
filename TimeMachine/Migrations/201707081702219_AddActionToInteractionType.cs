namespace TimeMachine.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddActionToInteractionType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InteractionTypes", "Action", c => c.Int(nullable: false));
            Sql("Update dbo.InteractionTypes set Action = 1 Where Id in (1,3);" +
                 "Update dbo.InteractionTypes set Action = 2 Where Id in (2, 4); ");
        }

        public override void Down()
        {
            DropColumn("dbo.InteractionTypes", "Action");
        }
    }
}
