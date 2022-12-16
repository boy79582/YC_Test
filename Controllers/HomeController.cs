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
        [HttpPost]
        public string getData()
        {
            var DT = DB_personnelData.getData();
            return JsonConvert.SerializeObject(DT);
        }
        [HttpPost]
        public string insertData(string JSON_newPersonnel)
        {
            var response = DB_personnelData.insertData(JSON_newPersonnel);
            return JsonConvert.SerializeObject(response);
        }
        [HttpPost]
        public string removeData(string JSON_Personnel)
        {
            var response = DB_personnelData.removeData(JSON_Personnel);
            return JsonConvert.SerializeObject(response);
        }
        [HttpPost]
        public string UpdateData(string JSON_Personnel)
        {
            var response = DB_personnelData.UpdateData(JSON_Personnel);
            return JsonConvert.SerializeObject(response);
        }
    }
}