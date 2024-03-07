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
    public class PlaneConfiguration
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.ToTable("MyPlanes");
            builder.Property(p => p.PlaneId).HasColumnName("PlaneId");
            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");
            // Other configurations...
        }
    }
}
