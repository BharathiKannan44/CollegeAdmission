namespace CollegeAdmission.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CollegeDepartments", "CollegeCode", "dbo.Colleges");
            DropIndex("dbo.CollegeDepartments", new[] { "CollegeCode" });
            DropIndex("dbo.Colleges", new[] { "CollegeWebsite" });
            DropIndex("dbo.Users", new[] { "EmailId" });
            AlterColumn("dbo.CollegeDepartments", "CollegeCode", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Colleges", "CollegeWebsite", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Users", "EmailId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.CollegeDepartments", "CollegeCode");
            CreateIndex("dbo.Colleges", "CollegeWebsite", unique: true);
            CreateIndex("dbo.Users", "EmailId", unique: true);
            AddForeignKey("dbo.CollegeDepartments", "CollegeCode", "dbo.Colleges", "CollegeCode", cascadeDelete: true);
            AlterStoredProcedure(
                "dbo.College_Insert",
                p => new
                    {
                        CollegeCode = p.String(maxLength: 8),
                        CollegeName = p.String(maxLength: 100),
                        CollegeWebsite = p.String(maxLength: 50),
                    },
                body:
                    @"INSERT [dbo].[Colleges]([CollegeCode], [CollegeName], [CollegeWebsite])
                      VALUES (@CollegeCode, @CollegeName, @CollegeWebsite)"
            );
            
            AlterStoredProcedure(
                "dbo.College_Update",
                p => new
                    {
                        CollegeCode = p.String(maxLength: 8),
                        CollegeName = p.String(maxLength: 100),
                        CollegeWebsite = p.String(maxLength: 50),
                    },
                body:
                    @"UPDATE [dbo].[Colleges]
                      SET [CollegeName] = @CollegeName, [CollegeWebsite] = @CollegeWebsite
                      WHERE ([CollegeCode] = @CollegeCode)"
            );
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollegeDepartments", "CollegeCode", "dbo.Colleges");
            DropIndex("dbo.Users", new[] { "EmailId" });
            DropIndex("dbo.Colleges", new[] { "CollegeWebsite" });
            DropIndex("dbo.CollegeDepartments", new[] { "CollegeCode" });
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Users", "EmailId", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.Colleges", "CollegeWebsite", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.CollegeDepartments", "CollegeCode", c => c.String(maxLength: 8));
            CreateIndex("dbo.Users", "EmailId", unique: true);
            CreateIndex("dbo.Colleges", "CollegeWebsite", unique: true);
            CreateIndex("dbo.CollegeDepartments", "CollegeCode");
            AddForeignKey("dbo.CollegeDepartments", "CollegeCode", "dbo.Colleges", "CollegeCode");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
