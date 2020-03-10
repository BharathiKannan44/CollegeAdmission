namespace CollegeAdmission.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Colleges", "Department_DeptId", "dbo.Departments");
            DropIndex("dbo.Colleges", new[] { "Department_DeptId" });
            CreateTable(
                "dbo.DepartmentColleges",
                c => new
                    {
                        Department_DeptId = c.Int(nullable: false),
                        College_CollegeCode = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Department_DeptId, t.College_CollegeCode })
                .ForeignKey("dbo.Departments", t => t.Department_DeptId, cascadeDelete: true)
                .ForeignKey("dbo.Colleges", t => t.College_CollegeCode, cascadeDelete: true)
                .Index(t => t.Department_DeptId)
                .Index(t => t.College_CollegeCode);
            
            DropColumn("dbo.Colleges", "Department_DeptId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Colleges", "Department_DeptId", c => c.Int());
            DropForeignKey("dbo.DepartmentColleges", "College_CollegeCode", "dbo.Colleges");
            DropForeignKey("dbo.DepartmentColleges", "Department_DeptId", "dbo.Departments");
            DropIndex("dbo.DepartmentColleges", new[] { "College_CollegeCode" });
            DropIndex("dbo.DepartmentColleges", new[] { "Department_DeptId" });
            DropTable("dbo.DepartmentColleges");
            CreateIndex("dbo.Colleges", "Department_DeptId");
            AddForeignKey("dbo.Colleges", "Department_DeptId", "dbo.Departments", "DeptId");
        }
    }
}
