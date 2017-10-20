using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Data.Domain.comment;

namespace Data.Mapping
{
    public class CommentMap : EntityTypeConfiguration<comment>
    {
        public CommentMap()
        {
            this.ToTable("Comment");
        }
    }
}
