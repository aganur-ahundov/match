using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Match.Models;
using Match.ParsingCode;

namespace Match.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View( XBetParser.GetData() );
        }
        
    }
}