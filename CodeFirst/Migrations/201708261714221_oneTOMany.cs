namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oneTOMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        StandardID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StandardID);
            
            AddColumn("dbo.Students", "Standard_StandardID", c => c.Int());
            CreateIndex("dbo.Students", "Standard_StandardID");
            AddForeignKey("dbo.Students", "Standard_StandardID", "dbo.Standards", "StandardID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Standard_StandardID", "dbo.Standards");
            DropIndex("dbo.Students", new[] { "Standard_StandardID" });
            DropColumn("dbo.Students", "Standard_StandardID");
            DropTable("dbo.Standards");
        }
    }
}
