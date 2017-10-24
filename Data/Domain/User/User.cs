using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.User
{
    public class User : BaseEntity
    {
        public string  Name { get; set; }

        public int Acount { get; set; }

        public int IsAdmin { get; set; }

        public string password { get; set; }
    }
}
