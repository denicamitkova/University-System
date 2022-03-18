namespace Data1901321073.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        BirthDate = c.DateTime(nullable: false),
                        Age = c.Short(nullable: false),
                        Egn = c.String(nullable: false, maxLength: 20),
                        FacultyNumber = c.Int(nullable: false),
                        Major = c.String(nullable: false, maxLength: 30),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        BirthDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 20),
                        Subject = c.String(nullable: false, maxLength: 30),
                        ExperienceYear = c.Short(nullable: false),
                        Address = c.String(maxLength: 20),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        City = c.String(nullable: false, maxLength: 20),
                        Street = c.String(nullable: false, maxLength: 20),
                        StreetNumber = c.Short(nullable: false),
                        BuildIn = c.DateTime(nullable: false),
                        NumberStudents = c.Int(nullable: false),
                        WorldRanking = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Universities");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
        }
    }
}
