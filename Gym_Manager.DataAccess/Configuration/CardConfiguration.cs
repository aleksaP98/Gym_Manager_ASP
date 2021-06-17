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
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(x => x.Authentification).IsRequired();
            builder.HasIndex(x => x.Authentification).IsUnique();
            builder.Property(x => x.ExpiresAt).IsRequired();
            builder.HasOne(x => x.Membership).WithMany(x => x.Cards).HasForeignKey(x => x.MembershipId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Trainer).WithOne(x => x.Card).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User).WithOne(x => x.Card).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
