using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BTSSWeb.Models
{
    public class BTSSWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BTSSWebContext() : base("name=BTSSWebContext")
        {
        }

        public System.Data.Entity.DbSet<BTSSWeb.Models.Users> Users { get; set; }
        public System.Data.Entity.DbSet<BTSSWeb.Models.Applications> Applications { get; set; }
        public System.Data.Entity.DbSet<BTSSWeb.Models.ApplicationGroups> ApplicationGroups { get; set; }
        public System.Data.Entity.DbSet<BTSSWeb.Models.ApplicationGroupModules> ApplicationGroupModules { get; set; }
        public System.Data.Entity.DbSet<BTSSWeb.Models.ApplicationGroupTables> ApplicationGroupTables { get; set; }
        public System.Data.Entity.DbSet<BTSSWeb.Models.ApplicationGroupUsers> ApplicationGroupUsers { get; set; }
        public System.Data.Entity.DbSet<BTSSWeb.Models.Audit> Audit { get; set; }
        public System.Data.Entity.DbSet<BTSSWeb.Models.Groups> Groups { get; set; }
        public System.Data.Entity.DbSet<BTSSWeb.Models.Tables> Tables { get; set; }
        public System.Data.Entity.DbSet<BTSSWeb.Models.Modules> Modules { get; set; }

    }
}
