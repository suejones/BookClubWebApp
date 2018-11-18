namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Diagnostics;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<WebApplication2.DAL.BookClubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "WebApplication2.DAL.BookClubContext";

        }

        protected override void Seed(WebApplication2.DAL.BookClubContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
