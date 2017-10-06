namespace BTSSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationGroupModules",
                c => new
                    {
                        AppGroupModuleID = c.Guid(nullable: false),
                        ApplicationGroupID = c.Guid(nullable: false),
                        ModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppGroupModuleID);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleID = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                    })
                .PrimaryKey(t => t.ModuleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Modules");
            DropTable("dbo.ApplicationGroupModules");
        }
    }
}
