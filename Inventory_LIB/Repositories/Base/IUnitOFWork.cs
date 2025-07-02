using Inventory_LIB.Repositories.Child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_LIB.Repositories.Base
{
  public  interface IUnitOFWork
    {
        public ICompanyRepo  CompanyRepo{get;}

        string Save();
    }
}
