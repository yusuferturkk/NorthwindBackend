using Microsoft.EntityFrameworkCore;
using NorthwindBackend.EntityLayer.Concrete;
using NorthwindBackend.CoreLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.DataAccessLayer.Concrete.Context
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= DESKTOP-T4IFV09\\SQLSERVER; initial catalog= Northwind; integrated security= true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
