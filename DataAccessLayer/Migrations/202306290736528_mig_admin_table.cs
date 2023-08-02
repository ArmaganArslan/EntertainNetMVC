namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        adminId = c.Int(nullable: false, identity: true),
                        adminUserName = c.String(maxLength: 50),
                        adminPassword = c.String(maxLength: 50),
                        adminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.adminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
