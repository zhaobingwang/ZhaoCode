namespace Project.Framework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable_temp_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.temp_table",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.temp_table");
        }
    }
}
