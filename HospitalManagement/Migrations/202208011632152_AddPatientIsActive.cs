namespace HospitalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "IsActive");
        }
    }
}
