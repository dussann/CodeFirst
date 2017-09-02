namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        NameOFCourse = c.String(),
                        Duration = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentsID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.StudentsID);
            
            CreateTable(
                "dbo.StudentsCourses",
                c => new
                    {
                        Students_StudentsID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Students_StudentsID, t.Course_CourseID })
                .ForeignKey("dbo.Students", t => t.Students_StudentsID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Students_StudentsID)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentsCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.StudentsCourses", "Students_StudentsID", "dbo.Students");
            DropIndex("dbo.StudentsCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.StudentsCourses", new[] { "Students_StudentsID" });
            DropTable("dbo.StudentsCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
