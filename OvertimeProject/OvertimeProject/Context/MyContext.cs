using Microsoft.EntityFrameworkCore;
using OvertimeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OvertimeProject.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employee)
                .WithOne(e => e.Department);

            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Account)
                .WithOne(a => a.Employee)
                .HasForeignKey<Account>(a => a.AccountId);

            modelBuilder.Entity<Role>()
                .HasMany(p => p.AccountRoles)
                .WithOne(a => a.Role);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountRoles)
                .WithOne(ar => ar.Account);

            modelBuilder.Entity<UserRequest>()
                .HasOne(e => e.Employee)
                .WithMany(ur => ur.UserRequests)
                .HasForeignKey(ur => ur.NIK);

            modelBuilder.Entity<Request>()
                .HasMany(oa => oa.UserRequests)
                .WithOne(oe => oe.Request);

            /*modelBuilder.Entity<Employee>()
                .HasOne(m => m.Manager)
                .WithMany(e => e.Employees)
                .HasForeignKey(e => e.ManagerId);*/

            //modelBuilder.Entity<AccountRole>().HasKey(ar => new { ar.AccountId, ar.RoleId });
        }

    }
}
