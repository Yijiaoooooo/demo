using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.Article;
using Data.Domain.comment;
using Data.Respository;
using Core.PagedList;
using Data.ViewModels.ArticleDetail;

namespace BLL.List
{
    public class ListService : ILists
    {
        private readonly IRepository<Article> _articleRepository;

        private readonly IRepository<comment> _commentRepository;

        public ListService(IRepository<Article> articleRepository, IRepository<comment> commentRepository)
        {
            _articleRepository = articleRepository;
            _commentRepository = commentRepository;
        }
        public IEnumerable<Article> GetList()
        {
            var source = _articleRepository.Table.ToList();
            return source;
        }
        public ArticleDetailViewModel GetArticleDetail(int id)
        {
            var article = _articleRepository.GetById(id);
            List<comment> comments = _commentRepository.Table.Where(c => c.ArticleId == id).ToList();

            var data = new ArticleDetailViewModel();

            data.Article.Id = article.Id;
            data.Article.author = article.author;
            data.Article.body = article.body;
            data.Article.CategoryDesc = article.CategoryDesc;
            data.Article.CategoryId = article.CategoryId;
            data.Article.CreateTime = article.CreateTime;
            data.Article.title = article.title;
            data.Article.rowGuid = article.rowGuid;

            data.TotalComment = comments.Count();

            if (comments.Count() > 0)
            {
                foreach (var item in comments)
                {
                    var temp = new comment()
                    {
                        ArticleId = item.ArticleId,
                        Like = item.Like,
                        Id = item.Id,
                        IsEnable = item.IsEnable,
                        Hate = item.Hate,
                        CreateTime = item.CreateTime,
                        content = item.content,
                        rowGuid = item.rowGuid

                    };
                    data.comments.Add(temp);
                }
            }

            return data;
        }

        public void SaveComment(string m, int id)
        {
            var comment = new comment() {
                content = m,
                IsEnable = 0,
                Like = 0,
                Hate = 0,
                ArticleId = id,
            };

            _commentRepository.Insert(comment);
        }
        public void UpOrHate(string type, int id)
        {
            var model = _commentRepository.GetById(id);
            if (type == "U")
            {
                model.Like = model.Like + 1;
            }
            if (type == "D")
            {
                model.Hate = model.Hate + 1;
            }
            _commentRepository.Update(model);
        }
    }
}
