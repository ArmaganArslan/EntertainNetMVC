namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_content_addStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "contentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "contentStatus");
        }
    }
}
