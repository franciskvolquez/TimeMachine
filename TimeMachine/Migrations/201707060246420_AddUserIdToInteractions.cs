namespace TimeMachine.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUserIdToInteractions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interactions", "UserId", c => c.String(maxLength: 128));

            Sql("IF NOT EXISTS(select * from dbo.AspNetUsers where Id = 'af014fdf-b782-4e37-be64-8099f78ead60')" +
                    "INSERT INTO dbo.AspNetUsers(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)" +
                    "VALUES('af014fdf-b782-4e37-be64-8099f78ead60', 'imartinezvolquez@gmail.com', 0, 'ALQqee51FZRPnXrr6z9WaT86WwmzM+7rlGAK2yFoq2yEYREPwKFrOgCIbOm5QsdUyw==', '7e473bd5-4c19-44a3-a64f-d0d6c5278905', 0, 0, 1, 0, 'imartinezvolquez@gmail.com')");

            Sql("UPDATE dbo.Interactions SET userid = 'af014fdf-b782-4e37-be64-8099f78ead60'");

            CreateIndex("dbo.Interactions", "UserId");
            AddForeignKey("dbo.Interactions", "UserId", "dbo.AspNetUsers", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Interactions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Interactions", new[] { "UserId" });
            DropColumn("dbo.Interactions", "UserId");
        }
    }
}
