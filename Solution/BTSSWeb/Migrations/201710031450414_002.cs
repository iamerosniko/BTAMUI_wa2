namespace BTSSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationGroups",
                c => new
                    {
                        applicationGroupID = c.Guid(nullable: false),
                        ApplicationID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.applicationGroupID);
            
            CreateTable(
                "dbo.ApplicationGroupTables",
                c => new
                    {
                        AppGroupTableID = c.Guid(nullable: false),
                        ApplicationGroupID = c.Guid(nullable: false),
                        TableID = c.Int(nullable: false),
                        CanGet = c.Boolean(nullable: false),
                        CanPost = c.Boolean(nullable: false),
                        CanPut = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AppGroupTableID);
            
            CreateTable(
                "dbo.ApplicationGroupUsers",
                c => new
                    {
                        AppGroupUserID = c.Guid(nullable: false),
                        ApplicationGroupID = c.Guid(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppGroupUserID);
            
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        AuditID = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Application = c.String(),
                        Table = c.String(),
                        Action = c.String(),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.AuditID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableID = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TableID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tables");
            DropTable("dbo.Groups");
            DropTable("dbo.Audits");
            DropTable("dbo.ApplicationGroupUsers");
            DropTable("dbo.ApplicationGroupTables");
            DropTable("dbo.ApplicationGroups");
        }
    }
}
