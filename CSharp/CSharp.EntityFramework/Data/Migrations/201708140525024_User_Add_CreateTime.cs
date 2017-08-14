namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Add_CreateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UpdateTime", c => c.DateTime(nullable: false,defaultValueSql:"GetDate()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UpdateTime");
        }
    }
}
