using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {



            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, Name = "Aman" },
                new User { ID = 2, Name = "Anthony" },
                new User { ID = 3, Name = "Akash" },
                new User { ID = 4 ,Name = "Aanand" },
                new User { ID = 5, Name = "Akansha" },
                new User { ID = 6, Name = "Aastha" }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, desc = "Dev", UserID = 1 },
                new Role { Id = 2, desc = "Testing", UserID = 2 },
                new Role { Id = 3, desc = "Analyst", UserID = 3 },
                new Role { Id = 4, desc = "HR", UserID = 4 },
                new Role { Id = 5, desc = "Requisition", UserID = 6 }
         
            );

            //fluent API to define the relation
            modelBuilder.Entity<Role>()
            .HasOne(r => r.User)           
            .WithMany(u => u.Role)        
            .HasForeignKey(r => r.UserID);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
