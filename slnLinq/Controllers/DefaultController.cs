using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace slnLinq.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        { 
            return View();
        }

        public string ShowArrayDesc()
        {
            int[] score = new int[] { 78, 99, 20, 100, 66 };
            string show = string.Empty;
            //Linq擴充方法
            var result = score.OrderBy(m => m);
            //var result=from m in score
            //           orderby m descending
            //           select m;
            show = "遞減排序";
            foreach(var m in result)
            {
                show += m + ",";
            }
            show += "<br />";
            show += "總合:" + result.Sum()+"<br />";
            show += "平均:" + result.Average();
            return show;

        }
        public string LoginMember(string uid, string pwd)
        {
            Member[] members = new Member[]
            {
            new Member{UId="tom",Pwd="123",Name="湯姆"},
            new Member{UId="jasper",Pwd="456",Name="賈斯柏"},
            new Member{UId="mary",Pwd="789",Name="馬力"}
            };

            var result = members
                .Where(m => m.UId == uid && m.Pwd == pwd)
                .FirstOrDefault();

            string show = string.Empty;
            if (result != null)
            {
                show = result.Name + "歡迎進入系統";
                
            }
            else
            {
                show = "帳號或密碼錯誤";
            }
            return show;
        }
    }
}