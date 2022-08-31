namespace HospitalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyPatientAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
