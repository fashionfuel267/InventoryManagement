using Inventory_LIB.Models;
using Inventory_LIB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_LIB.Repositories.Child
{
    public class UnitOfWork : IUnitOFWork
    {
        private ICompanyRepo companyRepo;
        public InventoryContext _context;
        public UnitOfWork(InventoryContext context)
        {
            _context = context;
        }
        public ICompanyRepo CompanyRepo
        {
            get
            {
                if(companyRepo==null)
                {
                    companyRepo = new CompanyRepo(_context);
                }
                return companyRepo;
            }
        }
     public   ICompanyBranchRepo companyBranchRepo;
        public ICompanyBranchRepo CompanyBranchRepo
        {
            get
            {
                if(companyBranchRepo==null)
                {
                    companyBranchRepo =new CompanyBranchRepo(_context);
                }
                return companyBranchRepo;
            }
        }

        public string Save()
        {
           if(_context.SaveChanges()>0)
            {
                return "Operation success";
            }
           else
            {
                return "Operation failed";
            }
        }
    }
}
