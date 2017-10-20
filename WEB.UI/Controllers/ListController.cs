using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Domain.Reservation;
using BLL.List;
using Data.Domain.comment;
using Newtonsoft.Json.Linq;

namespace WEB.UI.Controllers
{
    public class ListController : BaseController
    {
        private readonly ILists _ListService;
        public ListController(ILists ListService) {
            this._ListService = ListService;
        }
        public ActionResult Index()
        {
            var model = _ListService.GetList();
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var model = _ListService.GetArticleDetail(id);
            return View(model);

        }
        public ActionResult commentUp(string comment, int id)
        {
            _ListService.SaveComment(comment, id);
            return RedirectToAction("Detail", new { id = id });
        }

        public JObject UpOrHate(string type, int id)
        {
            try
            {
                _ListService.UpOrHate(type, id);
                return ToAjaxResult<comment>(true);
            }
            catch
            {
                return ToAjaxResult<comment>(false);
            }
        }
    }
}