namespace WCFServiceWebRole1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TempContext : DbContext
    {
        public TempContext()
            : base("name=TempContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Temperatur> Temperatur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany(e => e.Temperatur)
                .WithRequired(e => e.Location1)
                .HasForeignKey(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Temperatur)
                .WithRequired(e => e.Status1)
                .HasForeignKey(e => e.Status)
                .WillCascadeOnDelete(false);
        }
    }
}
