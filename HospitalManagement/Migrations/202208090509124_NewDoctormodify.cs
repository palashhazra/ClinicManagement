namespace HospitalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDoctormodify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Department", c => c.String());
            AddColumn("dbo.Doctors", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doctors", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "IsActive");
            DropColumn("dbo.Doctors", "DOB");
            DropColumn("dbo.Doctors", "Department");
        }
    }
}
