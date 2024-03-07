using AM.ApplicationCore.Domain;
using AM.infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.infrastructure
{
    public class AMContext : DbContext
    {
        // DbSet Declaration
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                Initial Catalog=AirportManagementUpdatedDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            //1stMethod
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());


            //2nd method
            //modelBuilder.Entity<Passenger>()
            //                .OwnsOne(p => p.PassengerName,
            //                name =>
            //                {
            //                    name.Property(n => n.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
            //                    name.Property(n => n.LastName).IsRequired().HasColumnName("PassLastName");
            //                });



        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("date");

            //String should be 30 at least ! 
            //configurationBuilder.Properties<String>()
            //    .HaveMaxLength(30)

        }
    }
}