namespace HospitalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"Insert into [dbo].[AspNetUsers](Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName) values('6b799e9e-bb15-426f-8a13-cb0c883cd06b','palashjesus@gmail.com',0,'AGiPx35eMGiBO5oCzwKsz75hsZhyyFIveseKHVjdTQlFsBgS0R9rlwiqlIixtMOntQ==','fb8994bb-4da5-442c-8f50-456e24a95bb7',null,0,0,null,1,0,'palashjesus@gmail.com');
Insert into [dbo].[AspNetUsers](Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName) values('995ce46c-7b69-4bba-b86d-6b49c1dbb439','guest@guest.com',0,'AFQRAICWaGFbrhKf6cpwobb0qqPda7PEFS8Ob92NOsGdBYYAAFXwglItPH2MSwCtiw==','0ac0ce98-a636-4593-ab79-b522c2334f0b',null,0,0,null,1,0,'guest@guest.com');
Insert into [dbo].[AspNetRoles](Id,Name) values('0ffb37a5-20ef-43ab-b1ca-c8418b92ed4b','CanManagePatients');
Insert into [dbo].[AspNetUserRoles] (UserId,RoleId) values('6b799e9e-bb15-426f-8a13-cb0c883cd06b','0ffb37a5-20ef-43ab-b1ca-c8418b92ed4b');
");
        }
        
        public override void Down()
        {
        }
    }
}
