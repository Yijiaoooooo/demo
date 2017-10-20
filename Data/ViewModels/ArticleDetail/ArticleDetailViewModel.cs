using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.Article;
using Data.Domain.comment;

namespace Data.ViewModels.ArticleDetail
{
    public class ArticleDetailViewModel
    {
        public Article Article { get; set; }

        public List<comment> comments { get; set; }

        public ArticleDetailViewModel()
        {
            comments = new List<comment>();
            Article = new Article();
        }

        public int TotalComment { get; set; }
    }
}
