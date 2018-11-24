namespace DataContext.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext.ProductContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Database.ExecuteSqlCommand("delete Cominfoes");
            context.Database.ExecuteSqlCommand("delete Catagories");
            CatagorySeed.Seed(context);
            context.SaveChanges();
            CominfoSeed.Seed(context);
            context.SaveChanges();

        }
    }
}
