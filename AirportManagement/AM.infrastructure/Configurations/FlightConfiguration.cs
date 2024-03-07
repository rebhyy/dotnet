using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder
                .HasMany(f => f.Passengers)
                .WithMany(f => f.Flights)
                .UsingEntity(f => f.ToTable("VolsPassenger"));

            builder
                .HasOne(f => f.Plane)
                .WithMany(f => f.Flights)
                .HasForeignKey(f => f.PlaneFKey)
                .HasConstraintName("PlaneFK");


        }
    }
}
