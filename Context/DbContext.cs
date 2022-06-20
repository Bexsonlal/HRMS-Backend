using ASPNetCoreWebAPiDemo.DepartmentModels;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebAPiDemo.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions options) : base(options) { }
        DbSet<Employees> Employees
        {
            get;     
            set;   
        }

        DbSet<Departments> Departments
        {
            get;
            set;
        }
    }
}


