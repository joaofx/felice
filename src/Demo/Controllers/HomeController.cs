namespace Demo.Controllers
{
    using System.Web.Mvc;
    using Felice.Data;
    using Models;

    public class HomeController : Controller
    {
        private readonly Repository<Project> _projectRepository;

        public HomeController(Repository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ActionResult Index()
        {
            //// TODO: http://blog.slaks.net/2013-06-11/readonly-vs-immutable/
            return View(_projectRepository.All());
        }
    }
}