using Inlm_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlm_2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToContainer("Products").HasPartitionKey(x => x.Id);
           
        }

    }
}
