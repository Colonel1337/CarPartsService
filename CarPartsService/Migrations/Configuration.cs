namespace NIHFService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NIHFService.Models.CarPartsServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NIHFService.Models.CarPartsServiceContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.CarParts.AddOrUpdate(x => x.Id, new Models.CarPart() { Id = "6af10eb5-ad5b-4336-907c-04c89e42e96f", PartNumber = "00001", PartName = "Bumper", Description = "Front bumper", CarManufacturerName = "Dodge" });
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
