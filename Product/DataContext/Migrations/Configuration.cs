namespace DataContext.Migrations
{
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
            context.Database.ExecuteSqlCommand("delete Catagories");
            context.Database.ExecuteSqlCommand("delete Cominfoes");
            CatagorySeed.Seed(context);
            CominfoSeed.Seed(context);
        }
    }
}
