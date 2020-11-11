namespace CollegeAdmission.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserApplications", "CollegeCode", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.UserApplications", "DeptID", c => c.Int(nullable: false));
            CreateIndex("dbo.UserApplications", "CollegeCode");
            CreateIndex("dbo.UserApplications", "DeptID");
            AddForeignKey("dbo.UserApplications", "CollegeCode", "dbo.Colleges", "CollegeCode", cascadeDelete: true);
            AddForeignKey("dbo.UserApplications", "DeptID", "dbo.Departments", "DeptId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserApplications", "DeptID", "dbo.Departments");
            DropForeignKey("dbo.UserApplications", "CollegeCode", "dbo.Colleges");
            DropIndex("dbo.UserApplications", new[] { "DeptID" });
            DropIndex("dbo.UserApplications", new[] { "CollegeCode" });
            DropColumn("dbo.UserApplications", "DeptID");
            DropColumn("dbo.UserApplications", "CollegeCode");
        }
    }
}
