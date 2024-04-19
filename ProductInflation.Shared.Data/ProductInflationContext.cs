using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductInflation.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ProductInflation.Shared.Data
{
    public class ProductInflationContext : DbContext
    {
        public DbSet<Product> Producto { get; set; }
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductInflation;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public ProductInflationContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }

    }
}
