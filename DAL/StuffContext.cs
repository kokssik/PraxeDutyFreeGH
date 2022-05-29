using DutyFreePraxe.Models;
// using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
// using MySql.Data.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

using Microsoft.EntityFrameworkCore.SqlServer;

namespace DutyFreePraxe.DAL
{
    public class StuffContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=mydatabase.db;");
        }

        public DbSet<Models.Products> products { get; set; }

        public DbSet<Models.Users> users { get; set; }

    }
}