using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.Category;
using Data.Domain.Article;
using Data.Respository;
using Data.ViewModels.AdminViewModel;
using Data.Context;
using Data.ViewModels.Query;
using Core.PagedList;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using Core.PagedList;

namespace BLL.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Article> _articleRepository;
        private readonly IDbContext _context;

        public AdminService(IRepository<Category> categoryRepository, IRepository<Article> articleRepository, IDbContext context)
        {
            this._categoryRepository = categoryRepository;
            this._articleRepository = articleRepository;
            this._context = context;
        }
        public AdminViewModel GetAllViewModel()
        {
            var categorySource = _categoryRepository.Table.Where(c => c.IsActive == 1).ToList();
            var articleSource = _articleRepository.Table.ToList();

            var categoryModel = new PagedList<Category>(categorySource, 6);
            var articleModel = new PagedList<Article>(articleSource, 6);

            var model = new AdminViewModel();

            foreach (var item in categoryModel)
            {
                var temp = new Category();
                temp.desc = item.desc;
                temp.Id = item.Id;
                model.Categorys.Add(temp);
            }
            model.CategoryPages = categoryModel.TotalPages;

            foreach (var item in articleModel)
            {
                var temp = new Article();
                temp.Id = item.Id;
                temp.title = item.title;
                temp.body = item.body;
                temp.author = item.author;
                temp.CreateTime = item.CreateTime;
                temp.CategoryDesc = item.CategoryDesc;

                model.Articles.Add(temp);
                
            }
            model.ArticlePages = articleModel.TotalPages;

            foreach (var item in categorySource)
            {
                var temp = new Category();
                temp.desc = item.desc;
                temp.Id = item.Id;
                model.AllCate.Add(temp);
            }

            return model;
        }

        public IPagedList<Category> GetCatePageList(int pageIndex, int pageSize)
        {
            var categorySource = _categoryRepository.Table.Where(c => c.IsActive == 1).ToList();
            var categoryModel = new PagedList<Category>(categorySource, pageSize, pageIndex);

            return categoryModel;
        }

        public IPagedList<Article> GetArticlePageList(int pageIndex, int pageSize)
        {
            var articleSource = _articleRepository.Table.ToList();
            var ArticleModel = new PagedList<Article>(articleSource, pageSize, pageIndex);

            return ArticleModel;
        }

        public IPagedList<Category> AddCotegory(string desc)
        {
            var one = new Category();
            one.desc = desc;
            one.IsActive = 1;
            _categoryRepository.Insert(one);

            var model = GetCatePageList(1, 6);

            return model;
        }
        public ArticleEditorViewModel ArticleEditor(int id)
        {
            var Categorys = _categoryRepository.Table.Where(c => c.IsActive == 1).ToList();
            var model = new ArticleEditorViewModel();

            foreach(var item in Categorys)
            {
                var temp = new Category();
                temp.Id = item.Id;
                temp.desc = item.desc;
                model.Categorys.Add(temp);
            }

            if (id == 0)
            {
                model.Article = new Article();
            }
            else
            {
                var article = _articleRepository.GetById(id);

                model.Article.Id = article.Id;
                model.Article.title = article.title;
                model.Article.author = article.author;
                model.Article.body = article.body;
                model.Article.CategoryId = article.CategoryId;
            }

            return model;
            
        }

        public void ArticleEditor(ArticleEditorViewModel vm, string Categorys) {
            string[] a = Categorys.Split('-');
            int CId = Convert.ToInt32(a[0]);
 
            if (vm.Article.Id == 0)
            {
                var Article = new Article();
                Article.title = vm.Article.title;
                Article.author = vm.Article.author;
                Article.CategoryId = CId;
                Article.CategoryDesc = a[1];
                Article.body = vm.Article.body;

                _articleRepository.Insert(Article);
            }
            else
            {
                var Article = _articleRepository.GetById(vm.Article.Id);

                Article.title = vm.Article.title;
                Article.author = vm.Article.author;
                Article.CategoryId = CId;
                Article.CategoryDesc = a[1];
                Article.body = vm.Article.body;

                _articleRepository.Update(Article);
            }
        }

        public void DeleteEntity(int id, string entity) {
            switch (entity)
            {
                case "Category":
                    var one = _categoryRepository.GetById(id);
                    one.IsActive = 0;
                    _categoryRepository.Update(one);
                    break;
                case "Article":
                    _articleRepository.Delete(id);
                    break;
            }
        }

        public void DeleteChecked(int[] ids, string entityType)
        {
            switch (entityType)
            {
                case "Category":
                    List<Category> cc = new List<Category>();
                    for (var i = 0; i < ids.Length; i++)
                    {
                        var a = _categoryRepository.GetById(ids[i]);
                        cc.Add(a);
                    }
                    _categoryRepository.Delete(cc);
                    break;
                case "Article":
                    List<Article> DA = new List<Article>();
                    for (var i = 0; i < ids.Length; i++)
                    {
                        var a = _articleRepository.GetById(ids[i]);
                        DA.Add(a);
                    }
                    _articleRepository.Delete(DA);
                    break;
            }
        }

        public void UpdateCategory(Category one)
        {
            var entity = _categoryRepository.GetById(one.Id);
            entity.desc = one.desc;

            _categoryRepository.Update(entity);
        }
        public JObject ArticleSearch(ArticleQueryViewModel q)
        {
            //DateTime? start = null;
            //DateTime? end = null;

            //if (Convert.ToDateTime(q.startDate) == Convert.ToDateTime("0001/1/1 0:00:00"))
            //{
            //    start = null;
            //}
            //else
            //{
            //    start = Convert.ToDateTime(q.startDate);
            //}
            //if (Convert.ToDateTime(q.endDate) == Convert.ToDateTime("0001/1/1 0:00:00"))
            //{
            //    end = null;
            //}
            //else
            //{
            //    end = Convert.ToDateTime(q.endDate);
            //}

            //SqlParameter title = new SqlParameter("title", q.title);
            //SqlParameter author = new SqlParameter("author", q.author);
            //SqlParameter categoryId = new SqlParameter("categoryId", q.categoryId);
            //SqlParameter startDate = new SqlParameter("startDate", start);
            //SqlParameter endDate = new SqlParameter("endDate", end);


            //var model = _context.ExecuteStoredProcedureList<Article>("PROC_ArticleSearch", title, author, categoryId, startDate, endDate);
            var model = _articleRepository.Table;

            if (!string.IsNullOrEmpty(q.title))
            {
                model = model.Where(c => c.title == q.title);
            };

            if (!string.IsNullOrEmpty(q.author))
            {
                model = model.Where(c => c.author == q.author);
            };

            if (q.categoryId != 0)
            {
                model = model.Where(c => c.CategoryId == q.categoryId);
            };

            if (Convert.ToDateTime(q.startDate) != Convert.ToDateTime("0001/1/1 0:00:00"))
            {
                model = model.Where(c => c.CreateTime > Convert.ToDateTime(q.startDate));
            };

            if (Convert.ToDateTime(q.endDate) != Convert.ToDateTime("0001/1/1 0:00:00"))
            {
                model = model.Where(c => c.CreateTime < Convert.ToDateTime(q.endDate));
            };

            var d = model.ToList();
            var data = new PagedList<Article>(d, 6, 1);

            return data.ToViewList();
        }
    }
}
