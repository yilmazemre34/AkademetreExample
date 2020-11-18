using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AkademetreExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AkademetreExample.Controllers
{
    public class HomeController : Controller
    {
        private List<Info> datas = new List<Info>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Info info)
        {
            datas.Add(info);

            return Json(new { aaData = datas });
        }

    }
}
