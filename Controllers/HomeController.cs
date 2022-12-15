using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YC_Test.Models;

namespace YC_Test.Controllers
{
    public class HomeController : Controller
    {
        DB_personnelData DB_personnelData = new Models.DB_personnelData();

        public ActionResult Index()
        {
            return View();
        }

        public string getData()
        {
            var DT = DB_personnelData.getData();
            return JsonConvert.SerializeObject(DT);
        }     
    }
}