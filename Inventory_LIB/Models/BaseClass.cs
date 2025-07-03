using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_LIB.Models
{
  public abstract  class BaseClass
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? CreatedBy { get; set; }
        [DataType(DataType.Date)]

        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        public string? CreatedIP { get; set; }
        [StringLength(50)]
        public string? ModifiedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; }
        [StringLength(50)]
        public string? ModifiedIP { get; set; }
        public bool IsActive { get; set; }
    }
}
