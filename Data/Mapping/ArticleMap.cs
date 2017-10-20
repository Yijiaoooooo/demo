using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Data.Domain.Article;

namespace Data.Mapping
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            this.ToTable("Article");
            this.HasKey(c => c.Id);

            this.Property(c => c.Id).HasColumnName("ArticleId");
            this.Property(c => c.author).IsRequired();
            this.Property(c => c.body);
        }
    }
}
