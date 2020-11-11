namespace CollegeAdmission.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserApplications", "TenthMark", c => c.Double(nullable: false));
            DropColumn("dbo.UserApplications", "TenththMark");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserApplications", "TenththMark", c => c.Double(nullable: false));
            DropColumn("dbo.UserApplications", "TenthMark");
        }
    }
}
