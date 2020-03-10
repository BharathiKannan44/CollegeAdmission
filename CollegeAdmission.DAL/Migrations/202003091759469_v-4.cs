namespace CollegeAdmission.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollegeDepartments", "AvailableSeats", c => c.Int(nullable: false));
            DropColumn("dbo.CollegeDepartments", "AdvanceFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CollegeDepartments", "AdvanceFee", c => c.Double(nullable: false));
            DropColumn("dbo.CollegeDepartments", "AvailableSeats");
        }
    }
}
