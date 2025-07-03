using Inventory_LIB.Models;
using Inventory_LIB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_LIB.Repositories.Child
{
    public interface ICompanyBranchRepo : IGenericRepo<CompanyBranch>
    {

    }
    public class CompanyBranchRepo : GenericRepo<CompanyBranch>, ICompanyBranchRepo
    {
        public CompanyBranchRepo(InventoryContext context) : base(context)
        {
        }
    }
}
