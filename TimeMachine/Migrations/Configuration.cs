namespace TimeMachine.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TimeMachine.Models.ApplicationDbContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TimeMachine.Models.ApplicationDbContext context)
        {
            //Create Interaction Types 
            /* context.InteractionTypes.AddOrUpdate(
                 new InteractionType { Name = "Arrival" },
                 new InteractionType { Name = "Lunch" },
                 new InteractionType { Name = "Back From Lunch" },
                 new InteractionType { Name = "Going Home" }
                  );
             */
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
