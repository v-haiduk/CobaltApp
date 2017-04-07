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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.CobaltContext context)
        {
            //context.UserAccounts.AddOrUpdate(
            //  p => p.Id,
            //  new Entities.UserAccount { Name = "admin", HashOfPassword = "123456" },
            //  new Entities.UserAccount { Name = "sam", HashOfPassword = "123456" }
            //);

        }
    }
}
