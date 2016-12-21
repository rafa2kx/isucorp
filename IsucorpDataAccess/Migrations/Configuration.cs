using System.Data.Entity.Migrations;
using IsucorpDataAccess.Models.DB;
using IsuCorpRound3.Models.Entities;

namespace IsucorpDataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<IsucorpContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "IsuCorpRound3.Models.DB.IsucorpContext";
        }

        protected override void Seed(IsucorpContext context)
        {
            context.ContactTypes.AddOrUpdate(
                ct => ct.ID,
                new ContactType {ID = 1, Name = "Individual", Description = "For individual Contacts"},
                new ContactType {ID = 2, Name = "Company", Description = "Companies are Contacts too."},
                new ContactType {ID = 3, Name = "Programmer", Description = "This contact type it's just the third"}
                );
        }
    }
}