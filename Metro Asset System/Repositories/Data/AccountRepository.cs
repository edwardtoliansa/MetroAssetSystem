using Dapper;
using Metro_Asset_System.Context;
using Metro_Asset_System.Handler;
using Metro_Asset_System.Models;
using Metro_Asset_System.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Metro_Asset_System.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, MyContext, string>
    {
        private readonly MyContext myContext;
        private readonly SendEmail sendEmail = new SendEmail();
        private readonly EmployeeRepository employeeRepository;
        public IConfiguration Configuration { get; }

        public AccountRepository(MyContext myContext, EmployeeRepository employeeRepository, IConfiguration configuration) : base(myContext)
        {
            myContext.Set<Account>();
            this.myContext = myContext;
            this.employeeRepository = employeeRepository;
            this.Configuration = configuration;
        }

        public int Register(RegisterVM registerVM)
        {

            var employee = new Employee()
            {
                NIK = employeeRepository.GenerateNIK(),
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                Phone = registerVM.Phone,
                Birthday = registerVM.Birthday,
                DepartmentId = registerVM.DepartmentId,
                Role = EmployeeRole.Employee
            };

            var account = new Account()
            {
                NIK = employee.NIK,
                Username =registerVM.Username,
                Password = employeeRepository.HashPassword("B0o7c@mp"),
                Status = StatusAccount.Restricted
            };

            var resPerson = employeeRepository.Create(employee);

            myContext.Add(account);

            var resAccount = myContext.SaveChanges();

            if (resAccount > 0 && resPerson > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
