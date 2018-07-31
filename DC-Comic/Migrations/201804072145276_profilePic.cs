namespace DC_Comic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profilePic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "profilePic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "profilePic");
        }
    }
}
