using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Newtonsoft.Json.Linq;
using Core.BusinessException;
using Core.PagedList;

namespace WEB.UI.Controllers
{
    public class BaseController : Controller
    {
        protected JObject ToAjaxResult(bool success, string message, object data = null, BusinessException bex = null, string url = null)
        {
            JObject jo = new JObject();
            jo.Add("success", success);

            if (bex != null)
            {
                if (bex.Errors.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("<b>{0}</b>", message);
                    for (int i = 0; i < bex.Errors.Count; i++)
                    {
                        var error = bex.Errors[i];
                        sb.AppendFormat("<br/>{0}. {1}", (i + 1), error.Message);
                    }
                    jo.Add("message", sb.ToString());
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("<b>{0}</b>", message);
                    sb.AppendFormat("<br/>1. {0}", bex.Message);
                    jo.Add("message", sb.ToString());
                }
            }
            else
            {
                jo.Add("message", message);
            }
            if (!string.IsNullOrEmpty(url))
                jo.Add("url", url);
            if (data != null)
                jo.Add("data", JObject.FromObject(data));
            return jo;
        }
        protected JObject ToAjaxResult<T>(bool success, IPagedList<T> data = null, string url = null)
        {
            JObject list = new JObject();

            if (data != null)
            {
                list.Add("TotalPages", data.TotalPages);

                JArray model = JArray.FromObject(data.ToList());

                list.Add("model", model);
            }
            
            list.Add("success", success);
            return list;
        }
    }
}