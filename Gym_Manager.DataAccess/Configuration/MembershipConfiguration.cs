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
    class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.GymMembership).IsRequired();
            builder.Property(x => x.FreePersonalTrainings).IsRequired();
            builder.Property(x => x.MobileApp).IsRequired();
            builder.Property(x => x.PersonalizedCard).IsRequired();
            builder.Property(x => x.ProgressTracker).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasMany(x => x.Cards).WithOne(x => x.Membership).HasForeignKey(x => x.MembershipId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
