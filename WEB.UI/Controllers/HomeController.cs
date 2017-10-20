using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Respository;
using Data.Domain.Reservation;

namespace WEB.UI.Controllers
{
    public class HomeController : BaseController
    {
        private IRepository<Reservation> _res;

        public HomeController(IRepository<Reservation> res)
        {
            this._res = res;
        }
        public ActionResult Index()
        {
            //var model = this._res.Table;
            return View("Summary");
        }
        public ActionResult Add(Reservation e)
        {
            _res.Insert(e);
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            this._res.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Update(Reservation res)
        {
            this._res.Update(res);
            return RedirectToAction("Index");
        }
    }
}