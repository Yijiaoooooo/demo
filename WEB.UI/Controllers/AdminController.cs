using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Admin;
using Data.Domain.Category;
using Data.Domain.Article;
using Data.ViewModels.AdminViewModel;
using Newtonsoft.Json.Linq;
using Data.ViewModels;
using Data.ViewModels.Query;

namespace WEB.UI.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
        }
        public ActionResult Index()
        {
            var model = _adminService.GetAllViewModel();
            return View(model);
        }
        public JObject AddCategory(string desc)
        {
            try
            {
                var model = _adminService.AddCotegory(desc);
                return ToAjaxResult<Category>(true, model);
            }
            catch
            {
                return ToAjaxResult<Category>(false);
            }

        }
        public ActionResult ArticleEditor(int id) {
            try
            {
                var model = _adminService.ArticleEditor(id);
                return View(model);
            }
            catch
            {
                return View();
            }
            

            
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Editor(ArticleEditorViewModel vm, string Categorys) {
            try
            {
                _adminService.ArticleEditor(vm, Categorys);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
            
        }

        public JObject Getcategory(int pageIndex = 1, int pageSize = 6)
        {
            try
            {
                var data = _adminService.GetCatePageList(pageIndex, pageSize);
                return ToAjaxResult<Category>(true, data);
            }
            catch
            {
                return ToAjaxResult<Category>(false);
            }
        }
        public JObject GetArticle(int pageIndex = 1, int pageSize = 6)
        {
            try
            {
                var data = _adminService.GetArticlePageList(pageIndex, pageSize);
                return ToAjaxResult<Article>(true, data);
            }
            catch
            {
                return ToAjaxResult<Article>(false);
            }
        }

        public JObject DeleteEntity(int id, string entity)
        {
            try
            {
                _adminService.DeleteEntity(id, entity);
                return ToAjaxResult<Category>(true);
            }
            catch
            {
                return ToAjaxResult<Category>(false);
            }
            
        }
        public JObject DeleteChecked(int[] ids, string entityType)
        {
            try
            {
                _adminService.DeleteChecked(ids, entityType);
                return ToAjaxResult<Category>(true);
            }
            catch
            {
                return ToAjaxResult<Category>(false);
            }
        }

        public JObject UpdateCategory(Category one)
        {
            try
            {
                _adminService.UpdateCategory(one);
                return ToAjaxResult<Category>(true);
            }
            catch
            {
                return ToAjaxResult<Category>(false);
            }
            
        }
        public JObject ArticleSearch(ArticleQueryViewModel query)
        {
            var d = _adminService.ArticleSearch(query);
            return d;
        }
    }
}