namespace CollegeAdmission.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v31 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserApplications", new[] { "EmailId" });
            DropColumn("dbo.UserApplications", "FirstName");
            DropColumn("dbo.UserApplications", "LastName");
            DropColumn("dbo.UserApplications", "Gender");
            DropColumn("dbo.UserApplications", "Dob");
            DropColumn("dbo.UserApplications", "EmailId");
            DropColumn("dbo.UserApplications", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserApplications", "PhoneNumber", c => c.Long(nullable: false));
            AddColumn("dbo.UserApplications", "EmailId", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.UserApplications", "Dob", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserApplications", "Gender", c => c.String(nullable: false, maxLength: 6));
            AddColumn("dbo.UserApplications", "LastName", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.UserApplications", "FirstName", c => c.String(nullable: false, maxLength: 40));
            CreateIndex("dbo.UserApplications", "EmailId", unique: true);
        }
    }
}
