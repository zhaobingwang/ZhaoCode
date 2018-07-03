namespace Project.Framework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Price = c.Double(nullable: false),
                        Remark = c.String(unicode: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
