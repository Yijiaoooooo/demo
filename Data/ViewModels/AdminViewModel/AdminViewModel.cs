using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.Category;
using Data.Domain.Article;

namespace Data.ViewModels.AdminViewModel
{
    public class AdminViewModel
    {
        public AdminViewModel()
        {
            Categorys = new List<Category>();
            Articles = new List<Article>();
            AllCate = new List<Category>();
        }

        public List<Category> Categorys { get; set; }

        public List<Category> AllCate { get; set; }

        public List<Article> Articles { get; set; }

        public int CategoryPages { get; set; }

        public int ArticlePages { get; set; }
    }
}
