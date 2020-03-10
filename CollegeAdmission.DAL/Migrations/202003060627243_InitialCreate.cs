namespace CollegeAdmission.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollegeDepartments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        CollegeCode = c.String(maxLength: 128),
                        AdvanceFee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Colleges", t => t.CollegeCode)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId)
                .Index(t => t.CollegeCode);
            
            CreateTable(
                "dbo.Colleges",
                c => new
                    {
                        CollegeCode = c.String(nullable: false, maxLength: 128),
                        CollegeName = c.String(),
                        CollegeWebsite = c.String(),
                        Department_DeptId = c.Int(),
                    })
                .PrimaryKey(t => t.CollegeCode)
                .ForeignKey("dbo.Departments", t => t.Department_DeptId)
                .Index(t => t.Department_DeptId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                    })
                .PrimaryKey(t => t.DeptId)
                .Index(t => t.DeptId, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Dob = c.DateTime(nullable: false),
                        EmailId = c.String(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollegeDepartments", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.Colleges", "Department_DeptId", "dbo.Departments");
            DropForeignKey("dbo.CollegeDepartments", "CollegeCode", "dbo.Colleges");
            DropIndex("dbo.Departments", new[] { "DeptId" });
            DropIndex("dbo.Colleges", new[] { "Department_DeptId" });
            DropIndex("dbo.CollegeDepartments", new[] { "CollegeCode" });
            DropIndex("dbo.CollegeDepartments", new[] { "DeptId" });
            DropTable("dbo.Users");
            DropTable("dbo.Departments");
            DropTable("dbo.Colleges");
            DropTable("dbo.CollegeDepartments");
        }
    }
}
