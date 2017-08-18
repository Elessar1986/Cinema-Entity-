namespace CinemaDataBaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        FilmName = c.String(maxLength: 4000),
                        FilmYear = c.Int(nullable: false),
                        Rating = c.Single(nullable: false),
                        Description = c.String(maxLength: 4000),
                        FilmPhotoFileName = c.String(maxLength: 4000),
                        FilmPhotoData = c.Binary(maxLength: 4000),
                        DirectorId_DirectorId = c.Int(),
                        GenreId_GenreId = c.Int(),
                    })
                .PrimaryKey(t => t.FilmId)
                .ForeignKey("dbo.Directors", t => t.DirectorId_DirectorId)
                .ForeignKey("dbo.Genres", t => t.GenreId_GenreId)
                .Index(t => t.DirectorId_DirectorId)
                .Index(t => t.GenreId_GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.CinemaRooms",
                c => new
                    {
                        CinemaRoomId = c.Int(nullable: false, identity: true),
                        RoomName = c.String(maxLength: 4000),
                        NumOfPlaces = c.Int(nullable: false),
                        NumOfBusyPlaces = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CinemaRoomId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        PlaceNum = c.Int(nullable: false),
                        CinemaRoomId_CinemaRoomId = c.Int(),
                        FilmId_FilmId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.CinemaRooms", t => t.CinemaRoomId_CinemaRoomId)
                .ForeignKey("dbo.Films", t => t.FilmId_FilmId)
                .Index(t => t.CinemaRoomId_CinemaRoomId)
                .Index(t => t.FilmId_FilmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "FilmId_FilmId", "dbo.Films");
            DropForeignKey("dbo.Tickets", "CinemaRoomId_CinemaRoomId", "dbo.CinemaRooms");
            DropForeignKey("dbo.Films", "GenreId_GenreId", "dbo.Genres");
            DropForeignKey("dbo.Films", "DirectorId_DirectorId", "dbo.Directors");
            DropIndex("dbo.Tickets", new[] { "FilmId_FilmId" });
            DropIndex("dbo.Tickets", new[] { "CinemaRoomId_CinemaRoomId" });
            DropIndex("dbo.Films", new[] { "GenreId_GenreId" });
            DropIndex("dbo.Films", new[] { "DirectorId_DirectorId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.CinemaRooms");
            DropTable("dbo.Genres");
            DropTable("dbo.Films");
            DropTable("dbo.Directors");
        }
    }
}
