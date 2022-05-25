using DutyFreePraxe.Models;
// using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DutyFreePraxe.DAL
{
    public class StuffContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Database=DutyFreeDB;Password=Root159@;User Id=mssql;Encrypt=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }

        public DbSet<Models.Products> products { get; set; }

    }
}