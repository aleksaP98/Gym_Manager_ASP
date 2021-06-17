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
    class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Gender).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasOne(x => x.Gym).WithMany(x => x.Trainers).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Card).WithOne(x => x.Trainer).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
