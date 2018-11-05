namespace codefirstdemo.Migrations
{
    using CodeFirstModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<codefirstdemo.CodeFirstModel.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //种子方法
        protected override void Seed(codefirstdemo.CodeFirstModel.CourseContext context)
        {
            //context.Database.ExecuteSqlCommand("delete courses");
            //context.Database.ExecuteSqlCommand("delete Students");
            //context.Database.ExecuteSqlCommand("delete departments");

            //DepartmentSeed.Seed(context);
            //CourseSeed.Seed(context);
            //StudentSeed.Seed(context);
        }
    }
}
