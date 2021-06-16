namespace CRUD.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUD.Models.CrudDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRUD.Models.CrudDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Categories.Add(new Models.Category
            {
                Id = 1,
                Name = "Soups"
            });
            context.Categories.Add(new Models.Category
            {
                Id = 2,
                Name = "Starters"
            });
            context.Categories.Add(new Models.Category
            {
                Id = 3,
                Name = "Main Course"
            });
            context.Categories.Add(new Models.Category
            {
                Id = 4,
                Name = "Chinese"
            });
            context.Categories.Add(new Models.Category
            {
                Id = 5,
                Name = "Deserts"
            });
        }
    }
}
