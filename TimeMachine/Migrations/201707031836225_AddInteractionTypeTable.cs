namespace TimeMachine.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddInteractionTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InteractionTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Interactions", "TypeId", c => c.Int(nullable: false));


            Sql("Insert into dbo.InteractionTypes(Name) values ('Arrival'); " +
                "Insert into dbo.InteractionTypes(Name) values ('Lunch'); " +
                "Insert into dbo.InteractionTypes(Name) values ('Back From Lunch'); " +
                "Insert into dbo.InteractionTypes(Name) values ('Going Home'); "
                );

            Sql("Update dbo.Interactions set TypeId = Type;");

            CreateIndex("dbo.Interactions", "TypeId");
            AddForeignKey("dbo.Interactions", "TypeId", "dbo.InteractionTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Interactions", "Type");
        }

        public override void Down()
        {
            AddColumn("dbo.Interactions", "Type", c => c.Int(nullable: false));
            Sql("Update dbo.Interactions set Type = TypeId;");
            DropForeignKey("dbo.Interactions", "TypeId", "dbo.InteractionTypes");
            DropIndex("dbo.Interactions", new[] { "TypeId" });
            DropColumn("dbo.Interactions", "TypeId");

            Sql("Truncate table dbo.InteractionTypes");
            DropTable("dbo.InteractionTypes");
        }
    }
}
