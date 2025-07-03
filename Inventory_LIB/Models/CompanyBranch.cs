using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_LIB.Models
{
   public class CompanyBranch : BaseClass
    {
        public string? Code { get; set; }

        public string Name { get; set; }

        public string? TIN { get; set; }

        public string? VatRegistryNo { get; set; }

        // public string FiscalYearStartDate { get; set; }

        public string? ContactPerson { get; set; }

        public string? ContactPersonDesignation { get; set; }

        public string? Phone { get; set; }
        public string? Fax { get; set; }

        public string? Email { get; set; }

        public string? Website { get; set; }

        public bool IsActive { get; set; }
        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }
        [ValidateNever]
        public CompanyInfo CompanyInfo { get; set; }

        public bool IsHeadOffice { get; set; }
         
    
}
}
