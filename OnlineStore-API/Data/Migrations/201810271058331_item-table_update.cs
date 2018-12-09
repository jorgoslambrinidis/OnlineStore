namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemtable_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Item", "Date");
        }
    }
}
