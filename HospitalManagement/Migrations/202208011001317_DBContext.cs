namespace HospitalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DateOfBirth", c => c.String());
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DateOfBirth");
           
        }
    }
}
