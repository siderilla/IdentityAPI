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
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

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

            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<Role>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>().Property(r => r.Description).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<UserRole>().ToTable("user_roles");
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(ur => ur.User)
                      .WithMany(u => u.UserRole)
                      .HasForeignKey(ur => ur.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(ur => ur.Role)
                      .WithMany(r => r.UserRole)
                      .HasForeignKey(ur => ur.RoleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }


    }
}
