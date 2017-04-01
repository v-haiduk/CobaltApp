namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.CobaltContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.EF.CobaltContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.UserAccounts.AddOrUpdate(
              p => p.Id,
              new Entities.UserAccount { Name = "admin", HashOfPassword = "123456" },
              new Entities.UserAccount { Name = "sam", HashOfPassword = "123456" }
            );

        }
    }
}
