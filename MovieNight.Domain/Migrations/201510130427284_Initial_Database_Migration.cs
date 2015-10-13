namespace MovieNight.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CastMembers",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        Rating = c.String(),
                        Length = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Nights",
                c => new
                    {
                        NightId = c.Int(nullable: false, identity: true),
                        ViewBy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NightId);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        NightId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Votes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Nights", t => t.NightId, cascadeDelete: true)
                .Index(t => t.NightId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "NightId", "dbo.Nights");
            DropForeignKey("dbo.Submissions", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Genres", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Writers", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Directors", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.CastMembers", "MovieId", "dbo.Movies");
            DropIndex("dbo.Submissions", new[] { "MovieId" });
            DropIndex("dbo.Submissions", new[] { "NightId" });
            DropIndex("dbo.Genres", new[] { "MovieId" });
            DropIndex("dbo.Writers", new[] { "MovieId" });
            DropIndex("dbo.Directors", new[] { "MovieId" });
            DropIndex("dbo.CastMembers", new[] { "MovieId" });
            DropTable("dbo.Submissions");
            DropTable("dbo.Nights");
            DropTable("dbo.Genres");
            DropTable("dbo.Writers");
            DropTable("dbo.Directors");
            DropTable("dbo.Movies");
            DropTable("dbo.CastMembers");
        }
    }
}
