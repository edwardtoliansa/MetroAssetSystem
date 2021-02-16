using Metro_Asset_System.Context;
using Metro_Asset_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, MyContext, string>
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);
        private readonly MyContext myContext;
        private readonly DbSet<Employee> employees;

        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            myContext.Set<Employee>();
            employees = myContext.Set<Employee>();
        }
        public string GenerateNIK()
        {
            var id = random.Next(1000000, 9999999);
            return id.ToString();
        }
        public string HashPassword(string password) {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
