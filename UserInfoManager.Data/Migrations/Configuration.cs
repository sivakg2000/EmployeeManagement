using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace UserInfoManager.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UserInfoManager.Data.Services.UserInfoManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "UserInfoManager.Data.Services.UserInfoManagerDbContext";
        }

        protected override void Seed(UserInfoManager.Data.Services.UserInfoManagerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}