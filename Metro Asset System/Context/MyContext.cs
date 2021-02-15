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
