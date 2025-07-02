using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_LIB.Models
{
  public  class InventoryContext:DbContext
    {
        public InventoryContext()
        {
            
        }
        public InventoryContext(DbContextOptions<InventoryContext>inv):base(inv)
        {
            
        }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress  ;Initial Catalog=dbInv; TrustServerCertificate=true;Trusted_connection=true; ");
        }
    }
}
