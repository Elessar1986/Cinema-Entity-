namespace CinemaDataBaseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roomMap : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CinemaRooms", "RoomXMLmap", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CinemaRooms", "RoomXMLmap");
        }
    }
}
