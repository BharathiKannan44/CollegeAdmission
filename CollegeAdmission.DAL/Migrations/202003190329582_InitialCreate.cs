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
                        CollegeCode = c.String(maxLength: 8),
                        AvailableSeats = c.Int(nullable: false),
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
                        CollegeCode = c.String(nullable: false, maxLength: 8),
                        CollegeName = c.String(nullable: false, maxLength: 100),
                        CollegeWebsite = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.CollegeCode)
                .Index(t => t.CollegeName, unique: true)
                .Index(t => t.CollegeWebsite, unique: true);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.DeptId)
                .Index(t => t.DeptName, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 75),
                        LastName = c.String(nullable: false, maxLength: 75),
                        Gender = c.String(nullable: false, maxLength: 5),
                        Dob = c.DateTime(nullable: false),
                        EmailId = c.String(nullable: false, maxLength: 75),
                        PhoneNumber = c.Long(nullable: false),
                        Password = c.String(nullable: false, maxLength: 25),
                        Role = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.EmailId, unique: true)
                .Index(t => t.PhoneNumber, unique: true);
            
            CreateStoredProcedure(
                "dbo.CollegeDepartment_Insert",
                p => new
                    {
                        DeptId = p.Int(),
                        CollegeCode = p.String(maxLength: 8),
                        AvailableSeats = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[CollegeDepartments]([DeptId], [CollegeCode], [AvailableSeats])
                      VALUES (@DeptId, @CollegeCode, @AvailableSeats)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[CollegeDepartments]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[CollegeDepartments] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "dbo.CollegeDepartment_Update",
                p => new
                    {
                        ID = p.Int(),
                        DeptId = p.Int(),
                        CollegeCode = p.String(maxLength: 8),
                        AvailableSeats = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[CollegeDepartments]
                      SET [DeptId] = @DeptId, [CollegeCode] = @CollegeCode, [AvailableSeats] = @AvailableSeats
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "dbo.CollegeDepartment_Delete",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[CollegeDepartments]
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "dbo.College_Insert",
                p => new
                    {
                        CollegeCode = p.String(maxLength: 8),
                        CollegeName = p.String(maxLength: 100),
                        CollegeWebsite = p.String(maxLength: 75),
                    },
                body:
                    @"INSERT [dbo].[Colleges]([CollegeCode], [CollegeName], [CollegeWebsite])
                      VALUES (@CollegeCode, @CollegeName, @CollegeWebsite)"
            );
            
            CreateStoredProcedure(
                "dbo.College_Update",
                p => new
                    {
                        CollegeCode = p.String(maxLength: 8),
                        CollegeName = p.String(maxLength: 100),
                        CollegeWebsite = p.String(maxLength: 75),
                    },
                body:
                    @"UPDATE [dbo].[Colleges]
                      SET [CollegeName] = @CollegeName, [CollegeWebsite] = @CollegeWebsite
                      WHERE ([CollegeCode] = @CollegeCode)"
            );
            
            CreateStoredProcedure(
                "dbo.College_Delete",
                p => new
                    {
                        CollegeCode = p.String(maxLength: 8),
                    },
                body:
                    @"DELETE [dbo].[Colleges]
                      WHERE ([CollegeCode] = @CollegeCode)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.College_Delete");
            DropStoredProcedure("dbo.College_Update");
            DropStoredProcedure("dbo.College_Insert");
            DropStoredProcedure("dbo.CollegeDepartment_Delete");
            DropStoredProcedure("dbo.CollegeDepartment_Update");
            DropStoredProcedure("dbo.CollegeDepartment_Insert");
            DropForeignKey("dbo.CollegeDepartments", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.CollegeDepartments", "CollegeCode", "dbo.Colleges");
            DropIndex("dbo.Users", new[] { "PhoneNumber" });
            DropIndex("dbo.Users", new[] { "EmailId" });
            DropIndex("dbo.Departments", new[] { "DeptName" });
            DropIndex("dbo.Colleges", new[] { "CollegeWebsite" });
            DropIndex("dbo.Colleges", new[] { "CollegeName" });
            DropIndex("dbo.CollegeDepartments", new[] { "CollegeCode" });
            DropIndex("dbo.CollegeDepartments", new[] { "DeptId" });
            DropTable("dbo.Users");
            DropTable("dbo.Departments");
            DropTable("dbo.Colleges");
            DropTable("dbo.CollegeDepartments");
        }
    }
}
