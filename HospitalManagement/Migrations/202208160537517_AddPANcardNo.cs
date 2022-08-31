namespace HospitalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPANcardNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PANCard", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PANCard");
        }
    }
}
