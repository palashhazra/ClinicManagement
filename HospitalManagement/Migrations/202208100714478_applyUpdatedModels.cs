namespace HospitalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyUpdatedModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "Department", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Dieseases", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Dieseases", c => c.String());
            AlterColumn("dbo.Doctors", "Department", c => c.String());
        }
    }
}
