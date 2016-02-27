namespace WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionCategories",
                c => new
                    {
                        ActionCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.ActionCategoryId);
            
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        ActionId = c.Int(nullable: false, identity: true),
                        ActionCategoryId = c.Int(nullable: false),
                        Name = c.String(),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.ActionId)
                .ForeignKey("dbo.ActionCategories", t => t.ActionCategoryId, cascadeDelete: true)
                .Index(t => t.ActionCategoryId);
            
            CreateTable(
                "dbo.CardActions",
                c => new
                    {
                        CardActionId = c.Int(nullable: false, identity: true),
                        CardId = c.Int(nullable: false),
                        ActionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardActionId)
                .ForeignKey("dbo.Actions", t => t.ActionId, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .Index(t => t.CardId)
                .Index(t => t.ActionId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CardCategoryId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.CardCategories", t => t.CardCategoryId, cascadeDelete: true)
                .Index(t => t.CardCategoryId);
            
            CreateTable(
                "dbo.CardCategories",
                c => new
                    {
                        CardCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CardCategoryId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        ActionId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Actions", t => t.ActionId, cascadeDelete: true)
                .Index(t => t.ActionId);
            
            CreateTable(
                "dbo.JourneyCards",
                c => new
                    {
                        JourneyCardId = c.Int(nullable: false, identity: true),
                        JourneyId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.JourneyCardId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.Journeys", t => t.JourneyId, cascadeDelete: true)
                .Index(t => t.JourneyId)
                .Index(t => t.CardId);
            
            AddColumn("dbo.Journeys", "Name", c => c.String());
            AddColumn("dbo.Journeys", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Journeys", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JourneyCards", "JourneyId", "dbo.Journeys");
            DropForeignKey("dbo.JourneyCards", "CardId", "dbo.Cards");
            DropForeignKey("dbo.Events", "ActionId", "dbo.Actions");
            DropForeignKey("dbo.CardActions", "CardId", "dbo.Cards");
            DropForeignKey("dbo.Cards", "CardCategoryId", "dbo.CardCategories");
            DropForeignKey("dbo.CardActions", "ActionId", "dbo.Actions");
            DropForeignKey("dbo.Actions", "ActionCategoryId", "dbo.ActionCategories");
            DropIndex("dbo.JourneyCards", new[] { "CardId" });
            DropIndex("dbo.JourneyCards", new[] { "JourneyId" });
            DropIndex("dbo.Events", new[] { "ActionId" });
            DropIndex("dbo.Cards", new[] { "CardCategoryId" });
            DropIndex("dbo.CardActions", new[] { "ActionId" });
            DropIndex("dbo.CardActions", new[] { "CardId" });
            DropIndex("dbo.Actions", new[] { "ActionCategoryId" });
            DropColumn("dbo.Users", "CreatedDate");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Journeys", "LastUpdate");
            DropColumn("dbo.Journeys", "CreatedDate");
            DropColumn("dbo.Journeys", "Name");
            DropTable("dbo.JourneyCards");
            DropTable("dbo.Events");
            DropTable("dbo.CardCategories");
            DropTable("dbo.Cards");
            DropTable("dbo.CardActions");
            DropTable("dbo.Actions");
            DropTable("dbo.ActionCategories");
        }
    }
}
