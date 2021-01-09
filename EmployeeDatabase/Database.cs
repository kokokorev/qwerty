using EmployeeDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDatabase
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=NIA\SQLEXPRESS;Initial Catalog=RepairWorkShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Employee> Employees { set; get; }
    }
}