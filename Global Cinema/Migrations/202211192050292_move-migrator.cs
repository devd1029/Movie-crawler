namespace Global_Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movemigrator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.movieTable", "imageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.movieTable", "imageUrl");
        }
    }
}
