using Gym_Manager.DataAccess.Configuration;
using Gym_Manager.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gym_Manager.DataAccess
{
    public class GymManagerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-IOKT76D;Initial Catalog=Gym_Manager;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TrainerConfiguration());
            modelBuilder.ApplyConfiguration(new MembershipConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new GymConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.Entity<GymImage>().HasKey(x => new { x.GymId, x.ImageId });
            modelBuilder.Entity<GymUser>().HasKey(x => new { x.GymId, x.UserId });

            modelBuilder.Entity<Card>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Membership>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Gym>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Trainer>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Image>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<UserUseCase>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TrainerUseCase>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<PersonalTraining>().HasQueryFilter(p => !p.IsDeleted);
        }
        public override int SaveChanges()
        {
            foreach (var entity in ChangeTracker.Entries())
            {
                if (entity.Entity is Entity e)
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsActive = true;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<GymImage> GymImages { get; set; }
        public DbSet<GymUser> GymUsers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<TrainerUseCase> TrainerUseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PersonalTraining> PersonalTrainings { get; set; }

    }
}
