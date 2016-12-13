using System.Linq;
using System.Web.Mvc;
using ToonSaloon.BLL;
using ToonSaloon.Models;

namespace ToonSaloon.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var repo = new PostManager().GetAllPosts();

            var model = from r in repo
                where r.Approved == Approved.Yes
                select r;

            return View(model.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult ViewSearchedStaticPage(int id)
        {
            var manager = new StaticManger();
            var model = manager.GetBySearch(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult ViewInfoPage(int id)
        {
            var manager = new StaticManger();
            var model = manager.GetPostByID(id);

            return View(model);
        }
    }
}