using Match.ParsingCode;
using System.Web.Mvc;

namespace Match.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View( XBetParser.GetFootballGames() );
        }
        
    }
}