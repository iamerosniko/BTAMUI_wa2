namespace BTSSWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modules", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modules", "IsActive");
        }
    }
}
