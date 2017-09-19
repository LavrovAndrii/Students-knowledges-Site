namespace ROZKLAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Days = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDay = c.Int(nullable: false),
                        IdTeatcher = c.Int(nullable: false),
                        IdSubject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.IdSubject, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.IdTeatcher, cascadeDelete: true)
                .ForeignKey("dbo.Days", t => t.IdDay, cascadeDelete: true)
                .Index(t => t.IdDay)
                .Index(t => t.IdTeatcher)
                .Index(t => t.IdSubject);
            
            CreateTable(
                "dbo.Ocinkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdStudent = c.Int(nullable: false),
                        IdLesson = c.Int(nullable: false),
                        Mark = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.IdStudent, cascadeDelete: true)
                .ForeignKey("dbo.Lessons", t => t.IdLesson, cascadeDelete: true)
                .Index(t => t.IdStudent)
                .Index(t => t.IdLesson);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdGroup = c.Int(nullable: false),
                        SureName = c.String(),
                        Name = c.String(),
                        Father = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.IdGroup, cascadeDelete: true)
                .Index(t => t.IdGroup);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSubject = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SureName = c.String(),
                        Name = c.String(),
                        Father = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "IdDay", "dbo.Days");
            DropForeignKey("dbo.Lessons", "IdTeatcher", "dbo.Teachers");
            DropForeignKey("dbo.Lessons", "IdSubject", "dbo.Subjects");
            DropForeignKey("dbo.Ocinkas", "IdLesson", "dbo.Lessons");
            DropForeignKey("dbo.Ocinkas", "IdStudent", "dbo.Students");
            DropForeignKey("dbo.Students", "IdGroup", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "IdGroup" });
            DropIndex("dbo.Ocinkas", new[] { "IdLesson" });
            DropIndex("dbo.Ocinkas", new[] { "IdStudent" });
            DropIndex("dbo.Lessons", new[] { "IdSubject" });
            DropIndex("dbo.Lessons", new[] { "IdTeatcher" });
            DropIndex("dbo.Lessons", new[] { "IdDay" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Groups");
            DropTable("dbo.Students");
            DropTable("dbo.Ocinkas");
            DropTable("dbo.Lessons");
            DropTable("dbo.Days");
        }
    }
}
