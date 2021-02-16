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
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOne(e => e.Department).WithMany(d => d.Employees).HasForeignKey(e => e.DepartmentId);
            //employee punya 1 department, department punya banyak employee,

            modelBuilder.Entity<Account>().HasOne(a => a.Employee).WithOne(e => e.Account).HasForeignKey<Account>(a => a.NIK);
            modelBuilder.Entity<Invoice>().HasOne(i => i.Employee).WithMany(e => e.Invoice).HasForeignKey(i => i.ProcurementEmployeeId);
            modelBuilder.Entity<PinaltyHistory>().HasOne(p => p.Invoice).WithOne(i => i.PinaltyHistory).HasForeignKey<PinaltyHistory>(p => p.Invoice);



            modelBuilder.Entity<ItemRequest>().HasOne(i => i.Asset).WithMany(a => a.ItemRequest).HasForeignKey(i => i.AssetId);
            modelBuilder.Entity<Asset>().HasOne(a => a.Category).WithMany(c => c.Asset).HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Pinalty>().HasOne(p => p.Asset).WithOne(a => a.Pinalty).HasForeignKey<Pinalty>(p => p.AssetId);


            modelBuilder.Entity<ItemRequest>().HasOne(i => i.Request).WithMany(r => r.ItemRequest).HasForeignKey(i => i.RequestId);

            modelBuilder.Entity<RequestDetail>().HasOne(r => r.Id)
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ItemRequest> ItemRequests { get; set; }
        public DbSet<Pinalty> Pinalties { get; set; }
        public DbSet<PinaltyHistory> PinaltyHistories { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}


















//modelBuilder.Entity<ItemRequest>().HasMany(i => i.Request).WithOne(r => r.ItemRequest).HasForeignKey(i => i.RequesterId);



//one to one
//modelBuilder.Entity<Account>()
//    .HasOne<Employee>(a => a.Employee)
//    .WithOne(e => e.Account)
//    .HasForeignKey<Employee>(e => e.NIK);
