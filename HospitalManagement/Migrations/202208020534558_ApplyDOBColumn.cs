namespace HospitalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDOBColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DateOfBirth");
        }
    }
}
