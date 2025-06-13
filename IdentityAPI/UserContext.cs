using Identity.Service.Model;
using IdentityAPI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityAPI.Model;

namespace Identity.Service
{
    public partial class UserContext: DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppConfig.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.Surname).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(100);
            
            modelBuilder.Entity<Request>().ToTable("requests");
            modelBuilder.Entity<Request>().HasKey(r => r.Id);
            modelBuilder.Entity<Request>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Request>().Property(r => r.Text).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Request>().Property(r => r.Url).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Request>(entity =>
                entity.HasOne(e => e.User)
                        .WithMany(x => x.Requests)
                        .HasForeignKey(e => e.UserId)
                        .OnDelete(DeleteBehavior.Cascade));
        }


    }
}
