namespace Project.Framework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnForUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "ModifyDate", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "ModifyDate");
        }
    }
}
