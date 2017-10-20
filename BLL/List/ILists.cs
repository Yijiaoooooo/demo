using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.Article;
using Data.ViewModels.ArticleDetail;

namespace BLL.List
{
    public interface ILists
    {
        IEnumerable<Article> GetList();

        ArticleDetailViewModel GetArticleDetail(int id);

        void SaveComment(string m, int id);

        void UpOrHate(string type, int id);
    }
}
