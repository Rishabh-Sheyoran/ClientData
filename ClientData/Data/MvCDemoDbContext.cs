using ClientData.Models.Domain;
using Microsoft.EntityFrameworkCore;

using System.Data.Entity;

namespace ClientData.Data
{
    public class MvCDemoDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MvCDemoDbContext(DbContextOptions options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Employee> Employees { get; set; }

    }
}
