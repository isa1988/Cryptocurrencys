using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cryptocurrency.Models;
using DataContent;
using Newtonsoft.Json.Linq;

namespace Cryptocurrency.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PageInfo pageInfo = new PageInfo();
            pageInfo.Title = "Главная";
            return View(pageInfo);
        }
    }
}