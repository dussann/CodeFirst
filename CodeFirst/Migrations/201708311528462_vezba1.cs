namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vezba1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseStudents", newName: "StudentsCourses");
            DropForeignKey("dbo.Addresses", "AddressID", "dbo.Students");
            DropIndex("dbo.Addresses", new[] { "AddressID" });
            DropPrimaryKey("dbo.Addresses");
            DropPrimaryKey("dbo.StudentsCourses");
            AlterColumn("dbo.Addresses", "AddressID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Addresses", "AddressID");
            AddPrimaryKey("dbo.StudentsCourses", new[] { "Students_StudentsID", "Course_CourseID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StudentsCourses");
            DropPrimaryKey("dbo.Addresses");
            AlterColumn("dbo.Addresses", "AddressID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.StudentsCourses", new[] { "Course_CourseID", "Students_StudentsID" });
            AddPrimaryKey("dbo.Addresses", "AddressID");
            CreateIndex("dbo.Addresses", "AddressID");
            AddForeignKey("dbo.Addresses", "AddressID", "dbo.Students", "StudentsID");
            RenameTable(name: "dbo.StudentsCourses", newName: "CourseStudents");
        }
    }
}
