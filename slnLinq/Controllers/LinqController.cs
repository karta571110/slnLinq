using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using slnLinq.Models;
using slnLinq.ViewModels;

namespace slnLinq.Controllers
{
    public class LinqController : Controller
    {
        // GET: Linq
        public ActionResult Index()
        {
            return View();
        }

        public string ShowEmployee()
        {
            NorthwindEntities db = new NorthwindEntities();

            var result = db.員工;

            string show = string.Empty;
            foreach(var m in result)
            {
                show += "編號：" + m.員工編號 + "<br />";
                show += "姓名：" + m.姓名 + m.稱呼 + "<br />";
                show += "職稱：" + m.稱呼 + "<hr>";

            }
            return show;
        }

        public string ShowByAddress(string keyword)
        {
            NorthwindEntities db = new NorthwindEntities();

            var result = db.客戶.Where(m => m.地址.Contains(keyword));

            string show = string.Empty;
            foreach(var m in result)
            {
                show += "公司：" + m.公司名稱 + "<br />";
                show += "姓名：" + m.連絡人 + "<br />";
                show += "地址：" + m.地址 + "<hr>";
            }
            return show;
        }

        public string ShowADO()
        {
            var aa = new List<Viewaa1>();
            using (var db = new aaEntities2())
            {

                var result = from q in db.aa1
                             orderby q.key descending
                             where q.key != 0
                             select new Viewaa1
                             {
                                 aa = q.aa,
                                 kk = q.kk,
                                 key = q.key
                             };
                if (result.Any())
                {
                    aa = result.ToList();
                }
            }
            string show = string.Empty;
            foreach (var m in aa)
            {
                show += "key：" + m.key + "<br />";
                show += "aa：" + m.aa + "<br />";
                show += "kk：" + m.kk + "<hr>";
            }
            return show;
        }

    }
}