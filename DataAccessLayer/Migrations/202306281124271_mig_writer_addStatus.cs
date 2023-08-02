namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_addStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "writerStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "writerStatus");
        }
    }
}
