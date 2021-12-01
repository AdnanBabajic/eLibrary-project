namespace eLibrary_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PdfLink = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 50),
                        Author = c.String(nullable: false, maxLength: 50),
                        Genre = c.String(nullable: false, maxLength: 50),
                        ReleaseYear = c.Int(nullable: false),
                        CoverImg = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhysicalBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 50),
                        IsAvailable = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Author = c.String(nullable: false, maxLength: 50),
                        Genre = c.String(nullable: false, maxLength: 50),
                        ReleaseYear = c.Int(nullable: false),
                        CoverImg = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhysicalBooks");
            DropTable("dbo.EBooks");
        }
    }
}
