using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.Article;
using Data.Domain.Category;

namespace Data.ViewModels.AdminViewModel
{
    public class ArticleEditorViewModel
    {
        public Article Article { get; set; }

        public List<Category> Categorys { get; set; }

        public ArticleEditorViewModel()
        {
            Categorys = new List<Category>();
            Article = new Article();
        }

    }
}
