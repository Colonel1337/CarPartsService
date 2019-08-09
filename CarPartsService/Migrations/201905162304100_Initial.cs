namespace NIHFService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarParts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PartNumber = c.String(nullable: false),
                        PartName = c.String(),
                        Description = c.String(),
                        CarManufacturerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarParts");
        }
    }
}
