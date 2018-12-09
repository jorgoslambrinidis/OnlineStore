namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Item", "User_Id", c => c.Int());
            CreateIndex("dbo.Item", "User_Id");
            AddForeignKey("dbo.Item", "User_Id", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "User_Id", "dbo.User");
            DropIndex("dbo.Item", new[] { "User_Id" });
            DropColumn("dbo.Item", "User_Id");
            DropTable("dbo.User");
        }
    }
}
