namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNewGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Crime')");
            Sql("INSERT INTO Genres (Name) VALUES ('Mystery')");
            Sql("INSERT INTO Genres (Name) VALUES ('Historical')");
            Sql("INSERT INTO Genres (Name) VALUES ('Horror')");
            Sql("INSERT INTO Genres (Name) VALUES ('Musical')");
            Sql("INSERT INTO Genres (Name) VALUES ('War')");
            Sql("INSERT INTO Genres (Name) VALUES ('Western')");
        }
        
        public override void Down()
        {
        }
    }
}
