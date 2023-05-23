namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGradeToTheses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GradeThesis",
                c => new
                    {
                        GradeId = c.Int(nullable: false),
                        ThesisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GradeId, t.ThesisId })
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Theses", t => t.ThesisId, cascadeDelete: false)
                .Index(t => t.GradeId)
                .Index(t => t.ThesisId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GradeThesis", "ThesisId", "dbo.Theses");
            DropForeignKey("dbo.GradeThesis", "GradeId", "dbo.Grades");
            DropIndex("dbo.GradeThesis", new[] { "ThesisId" });
            DropIndex("dbo.GradeThesis", new[] { "GradeId" });
            DropTable("dbo.GradeThesis");
        }
    }
}
