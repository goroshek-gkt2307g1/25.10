using _25._10.Models.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._10.Domain
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        public MyDatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DBSRV\\ag2025;Initial Catalog='VlasovaAA курсовая1';Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //настраиваем ограничение UNIQUE для Account
            modelBuilder.Entity<Account>().HasIndex(a => a.Username).IsUnique();

            //настраиваем начальные данные для справочников
            modelBuilder.Entity<Role>().HasData(Role.SeedData);
            modelBuilder.Entity<AccountStatus>().HasData(AccountStatus.SeedData);
        }
    }
}