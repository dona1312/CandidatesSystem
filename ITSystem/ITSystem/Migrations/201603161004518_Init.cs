namespace ITSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "ConsultantId", "dbo.Consultants");
            DropForeignKey("dbo.Notes", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Notes", new[] { "ConsultantId" });
            DropIndex("dbo.Notes", new[] { "CandidateId" });
            AddColumn("dbo.Candidates", "Notes", c => c.String());
            DropTable("dbo.Notes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsultantId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Candidates", "Notes");
            CreateIndex("dbo.Notes", "CandidateId");
            CreateIndex("dbo.Notes", "ConsultantId");
            AddForeignKey("dbo.Notes", "CandidateId", "dbo.Candidates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Notes", "ConsultantId", "dbo.Consultants", "Id", cascadeDelete: true);
        }
    }
}
