using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_LIB.Models
{
    public class ApplicationUser : IdentityUser
    {

    }
  public  class InventoryContext:IdentityDbContext<ApplicationUser>
    {
        public InventoryContext()
        {
            
        }
       
        public InventoryContext(DbContextOptions<InventoryContext>inv):base(inv)
        {
            
        }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<CompanyBranch> CompanyBranch { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress  ;Initial Catalog=dbInv05; TrustServerCertificate=true;Trusted_connection=true; ");
        }
    }
}
