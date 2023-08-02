namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_heading_addStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "headingStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "headingStatus");
        }
    }
}
