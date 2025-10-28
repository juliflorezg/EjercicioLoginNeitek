using Microsoft.EntityFrameworkCore;

namespace EjercicioLoginNeitekBackend.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserType>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserType>().HasData(
            new UserType { Id = 1, Type = "Admin", Description = "Admin user" },
            new UserType { Id = 2, Type = "Customer", Description = "Customer user" }
    );

            modelBuilder.Entity<UserType>()
                .HasIndex(u => u.Type)
                .IsUnique();
        }
    }
}
