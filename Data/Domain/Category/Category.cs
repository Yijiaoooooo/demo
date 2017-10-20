using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Category
{
    public class Category : BaseEntity
    {
        public string desc { get; set; }
        public int IsActive { get; set; }
        public int IsSystem { get; set; }
    }
}
