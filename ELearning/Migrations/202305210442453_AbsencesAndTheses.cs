namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbsencesAndTheses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                        Motivated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Theses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.ClassCourses",
                c => new
                    {
                        Class_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Class_Id, t.Course_Id })
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Class_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.ThesisClasses",
                c => new
                    {
                        Thesis_Id = c.Int(nullable: false),
                        Class_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Thesis_Id, t.Class_Id })
                .ForeignKey("dbo.Theses", t => t.Thesis_Id, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Thesis_Id)
                .Index(t => t.Class_Id);
            
            AddColumn("dbo.Grades", "Semester", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Absences", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Absences", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Theses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ThesisClasses", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.ThesisClasses", "Thesis_Id", "dbo.Theses");
            DropForeignKey("dbo.ClassCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.ClassCourses", "Class_Id", "dbo.Classes");
            DropIndex("dbo.ThesisClasses", new[] { "Class_Id" });
            DropIndex("dbo.ThesisClasses", new[] { "Thesis_Id" });
            DropIndex("dbo.ClassCourses", new[] { "Course_Id" });
            DropIndex("dbo.ClassCourses", new[] { "Class_Id" });
            DropIndex("dbo.Theses", new[] { "CourseId" });
            DropIndex("dbo.Absences", new[] { "StudentId" });
            DropIndex("dbo.Absences", new[] { "CourseId" });
            DropColumn("dbo.Grades", "Semester");
            DropTable("dbo.ThesisClasses");
            DropTable("dbo.ClassCourses");
            DropTable("dbo.Theses");
            DropTable("dbo.Absences");
        }
    }
}
