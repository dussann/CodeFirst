namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vezbanje11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentsCourses", newName: "CourseStudents");
            DropPrimaryKey("dbo.Addresses");
            DropPrimaryKey("dbo.CourseStudents");
            AlterColumn("dbo.Addresses", "AddressID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Addresses", "AddressID");
            AddPrimaryKey("dbo.CourseStudents", new[] { "Course_CourseID", "Students_StudentsID" });
            CreateIndex("dbo.Addresses", "AddressID");
            AddForeignKey("dbo.Addresses", "AddressID", "dbo.Students", "StudentsID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "AddressID", "dbo.Students");
            DropIndex("dbo.Addresses", new[] { "AddressID" });
            DropPrimaryKey("dbo.CourseStudents");
            DropPrimaryKey("dbo.Addresses");
            AlterColumn("dbo.Addresses", "AddressID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CourseStudents", new[] { "Students_StudentsID", "Course_CourseID" });
            AddPrimaryKey("dbo.Addresses", "AddressID");
            RenameTable(name: "dbo.CourseStudents", newName: "StudentsCourses");
        }
    }
}
