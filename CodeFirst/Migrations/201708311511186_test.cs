namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "AddressID", "dbo.Students");
            DropIndex("dbo.Addresses", new[] { "AddressID" });
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false),
                        Address1 = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateIndex("dbo.Addresses", "AddressID");
            AddForeignKey("dbo.Addresses", "AddressID", "dbo.Students", "StudentsID");
        }
    }
}
