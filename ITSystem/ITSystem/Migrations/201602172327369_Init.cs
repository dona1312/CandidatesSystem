namespace ITSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Rank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsultantId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consultants", t => t.ConsultantId, cascadeDelete: true)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.ConsultantId)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.ProgrammingLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CandidateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.UsedTechnologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CandidateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.ConsultantCandidates",
                c => new
                    {
                        Consultant_Id = c.Int(nullable: false),
                        Candidate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Consultant_Id, t.Candidate_Id })
                .ForeignKey("dbo.Consultants", t => t.Consultant_Id, cascadeDelete: true)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id, cascadeDelete: true)
                .Index(t => t.Consultant_Id)
                .Index(t => t.Candidate_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsedTechnologies", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.ProgrammingLanguages", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Notes", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Notes", "ConsultantId", "dbo.Consultants");
            DropForeignKey("dbo.ConsultantCandidates", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.ConsultantCandidates", "Consultant_Id", "dbo.Consultants");
            DropIndex("dbo.ConsultantCandidates", new[] { "Candidate_Id" });
            DropIndex("dbo.ConsultantCandidates", new[] { "Consultant_Id" });
            DropIndex("dbo.UsedTechnologies", new[] { "CandidateId" });
            DropIndex("dbo.ProgrammingLanguages", new[] { "CandidateId" });
            DropIndex("dbo.Notes", new[] { "CandidateId" });
            DropIndex("dbo.Notes", new[] { "ConsultantId" });
            DropTable("dbo.ConsultantCandidates");
            DropTable("dbo.UsedTechnologies");
            DropTable("dbo.ProgrammingLanguages");
            DropTable("dbo.Notes");
            DropTable("dbo.Consultants");
            DropTable("dbo.Candidates");
        }
    }
}
