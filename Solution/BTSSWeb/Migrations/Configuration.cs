namespace BTSSWeb.Migrations
{
    using BTSSWeb.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BTSSWeb.Models.BTSSWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BTSSWeb.Models.BTSSWebContext context)
        {
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

            context.Users.AddOrUpdate(x => x.UserID,
                   new Users()
                   {
                       UserID= 1,
                       UserLastName="Alvarez",
                       UserMiddleName="Cas",
                       UserFirstName="Eros Niko",
                       UserName="alverer",
                       IsActive=true
                   },
                   new Users()
                   {
                       UserID = 2,
                       UserLastName = "Sarmiento",
                       UserMiddleName = "Paras",
                       UserFirstName = "Federico",
                       UserName = "sarmife",
                       IsActive = true
                   },
                   new Users()
                   {
                       UserID=3,
                       UserLastName="Martirez",
                       UserMiddleName="",
                       UserFirstName="Albert Rick",
                       UserName="martiab",
                       IsActive=true
                   }

            );

            context.ApplicationGroups.AddOrUpdate(x=>x.ApplicationGroupID,
                new ApplicationGroups()
                {
                    ApplicationGroupID=new Guid("750bf47a-0cd0-486a-a40a-04c4e2416f0f"),
                    ApplicationID=1,
                    GroupID=1
                }
                    
            );
        }
    }
}
