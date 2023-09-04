using AssetManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementAPI
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<MeetingRoomAsset> MeetingRoomAssets { get; set; }

        public DbSet<VAllocatedSeat> VOverviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
               .Entity<VAllocatedSeat>()
               .ToView("AllocatedSeat")
               .HasKey(t => t.SeatId);

            modelBuilder
              .Entity<VUnAllocatedSeat>()
              .ToView("UnAllocatedSeat")
              .HasKey(t => t.SeatId);

            modelBuilder.Entity<Seat>()
            .HasOne(s => s.Employee)
            .WithMany()
            .HasForeignKey(s => s.EmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
