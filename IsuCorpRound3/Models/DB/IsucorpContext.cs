using System.Data.Common;
using System.Data.Entity;
using IsuCorpRound3.Migrations;
using IsuCorpRound3.Models.Entities;

namespace IsuCorpRound3.Models.DB
{
    public class IsucorpContext : DbContext
    {
        public IsucorpContext(DbConnection existingConnection, bool contextOwnConnection)
            : base(existingConnection, contextOwnConnection)
        {
        }

        public IsucorpContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IsucorpContext,
                Configuration>());
        }

        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ContactType>().MapToStoredProcedures();
            modelBuilder.Entity<Reservation>().MapToStoredProcedures();
        }
    }
}