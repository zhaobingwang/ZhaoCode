namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UpdateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UpdateTime", c => c.DateTime(nullable: false));
        }
    }
}
