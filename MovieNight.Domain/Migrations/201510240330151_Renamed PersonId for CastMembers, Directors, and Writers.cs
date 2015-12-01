namespace MovieNight.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedPersonIdforCastMembersDirectorsandWriters : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CastMembers");
            DropPrimaryKey("dbo.Directors");
            DropPrimaryKey("dbo.Writers");
            RenameColumn("dbo.CastMembers", "PersonId", "CastMemberId");
            RenameColumn("dbo.Directors", "PersonId", "DirectorId");
            RenameColumn("dbo.Writers", "PersonId", "WriterId");
            AddPrimaryKey("dbo.CastMembers", "CastMemberId");
            AddPrimaryKey("dbo.Directors", "DirectorId");
            AddPrimaryKey("dbo.Writers", "WriterId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Writers");
            DropPrimaryKey("dbo.Directors");
            DropPrimaryKey("dbo.CastMembers");
            RenameColumn("dbo.CastMembers", "CastMemberId", "PersonId");
            RenameColumn("dbo.Directors", "DirectorId", "PersonId");
            RenameColumn("dbo.Writers", "WriterId", "PersonId");
            AddPrimaryKey("dbo.Writers", "PersonId");
            AddPrimaryKey("dbo.Directors", "PersonId");
            AddPrimaryKey("dbo.CastMembers", "PersonId");
        }

            
    }
}
