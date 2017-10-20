using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.Category;
using Data.Domain.Article;
using Data.ViewModels.AdminViewModel;
using Data.ViewModels.Query;
using Newtonsoft.Json.Linq;
using Core.PagedList;

namespace BLL.Admin
{
    public interface IAdminService
    {
        AdminViewModel GetAllViewModel();

        IPagedList<Category> AddCotegory(string desc);

        ArticleEditorViewModel ArticleEditor(int id);

        void ArticleEditor(ArticleEditorViewModel vm, string Categorys);

        IPagedList<Category> GetCatePageList(int pageIndex, int pageSzie);

        IPagedList<Article> GetArticlePageList(int pageIndex, int pageSize);

        void DeleteEntity(int id, string entity);

        void DeleteChecked(int[] ids, string entityType);

        void UpdateCategory(Category one);

        JObject ArticleSearch(ArticleQueryViewModel q);
    }
}
