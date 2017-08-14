namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Add_Index_Name : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Users", new[] { "Id" }, name: "Index_Users_Id");
        }
        
        public override void Down()
        {
            DropIndex("Users", "Index_Users_Id");
        }
    }
}
