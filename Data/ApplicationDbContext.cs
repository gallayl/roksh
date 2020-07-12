using roksh.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace roksh.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<DeliveryState> DeliveryStates { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Item> Items { get; set; }
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        private void SeedDeliveryStates(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryState>().HasData(
                new DeliveryState() { Id = 1, Code = "WfPU", Description_EN = "Waiting for Pick Up", Description_HU = "Csomag a feladónál. Furátta vár." },
                new DeliveryState() { Id = 2, Code = "PU", Description_EN = "Picked up", Description_HU = "Csomag a futárnál. Depóba tart." },
                new DeliveryState() { Id = 3, Code = "ID", Description_EN = "In Depot", Description_HU = "Depóban van. Kiszállításra vár." },
                new DeliveryState() { Id = 4, Code = "OD", Description_EN = "On Delivery", Description_HU = "Kiszállítás alatt áll. Célba tart." },
                new DeliveryState() { Id = 5, Code = "DD", Description_EN = "Delivered", Description_HU = "Kiszállítva." });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>()
                .HasOne<Package>(item => item.Package).WithMany(package => package.Items);

            modelBuilder.Entity<Package>().HasOne<ApplicationUser>(p => p.Owner).WithMany(user => user.Packages);
            modelBuilder.Entity<Package>().HasOne<DeliveryState>(p => p.State);
            modelBuilder.Entity<Package>().HasIndex(p => p.Identifier).IsUnique();

            modelBuilder.Entity<DeliveryState>().HasIndex(p => p.Code).IsUnique();
            SeedDeliveryStates(modelBuilder);
        }
    }
}
