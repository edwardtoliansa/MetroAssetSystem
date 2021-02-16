using Metro_Asset_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Context
{
    public class MyContext : DbContext
    {
        public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PinaltyHistory> PinaltyHistories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Pinalty> Pinalties { get; set; }
        public DbSet<ItemRequest> ItemRequests { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(a => a.Employee).WithOne(e => e.Account).HasForeignKey<Account>(a => a.NIK);
            modelBuilder.Entity<Employee>().HasOne(e => e.Department).WithMany(d => d.Employees).HasForeignKey(e => e.DepartmentId);
            modelBuilder.Entity<Invoice>().HasOne(i => i.Employee).WithMany(e => e.Invoices).HasForeignKey(i=>i.ProcurementEmployeeId);
            modelBuilder.Entity<PinaltyHistory>().HasOne(p => p.Invoice).WithOne(i => i.PinaltyHistory).HasForeignKey<PinaltyHistory>(p => p.InvoiceId);
            modelBuilder.Entity<RequestDetail>().HasOne(rd => rd.Employee).WithMany(e => e.RequestDetails).HasForeignKey(rd => rd.EmployeeId);
            //modelBuilder.Entity<Employee>().HasOne(e => e.Manager).WithOne(m => m.Manager).HasForeignKey<Employee>(e => e.ManagerId);
        }

    }
}
