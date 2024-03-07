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
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.PassengerName, name =>
            {
                name.Property(n => n.FirstName).HasMaxLength(30).HasColumnName("PassFirstName");
                name.Property(n => n.LastName).IsRequired().HasColumnName("PassLastName");
            });

        }
    }
}
