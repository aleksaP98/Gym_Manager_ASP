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
    class PersonalTrainingConfiguration : IEntityTypeConfiguration<PersonalTraining>
    {
        public void Configure(EntityTypeBuilder<PersonalTraining> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.PersonalTrainings).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Trainer).WithMany(x => x.PersonalTrainings).HasForeignKey(x => x.TrainerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
