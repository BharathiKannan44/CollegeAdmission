namespace CollegeAdmission.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserApplications",
                c => new
                    {
                        ApplicationNumber = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        Gender = c.String(nullable: false, maxLength: 6),
                        Dob = c.DateTime(nullable: false),
                        EmailId = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.Long(nullable: false),
                        City = c.String(nullable: false, maxLength: 25),
                        TenththMark = c.Double(nullable: false),
                        TwelthMark = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationNumber)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EmailId, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserApplications", "UserId", "dbo.Users");
            DropIndex("dbo.UserApplications", new[] { "EmailId" });
            DropIndex("dbo.UserApplications", new[] { "UserId" });
            DropTable("dbo.UserApplications");
        }
    }
}
