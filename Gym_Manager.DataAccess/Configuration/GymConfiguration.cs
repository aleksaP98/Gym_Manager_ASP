using Gym_Manager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Manager.DataAccess.Configuration
{
    public class GymConfiguration : IEntityTypeConfiguration<Gym>
    {
        public void Configure(EntityTypeBuilder<Gym> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Address).IsRequired();

            builder.HasMany(x => x.Trainers).WithOne(x => x.Gym).HasForeignKey(x => x.GymId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.GymImages).WithOne(x => x.Gym).HasForeignKey(x => x.GymId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.GymUsers).WithOne(x => x.Gym).HasForeignKey(x => x.GymId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
