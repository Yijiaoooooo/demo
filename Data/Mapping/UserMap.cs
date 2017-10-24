using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Data.Domain.User;

namespace Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap() {
            this.ToTable("User");
        }
    }
}
