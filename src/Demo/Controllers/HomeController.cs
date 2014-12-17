using System.Web.Mvc;

namespace Demo.Controllers
{
    using Repositories;

    public class HomeController : Controller
    {
        private readonly ProjectRepository _projectRepository;

        public HomeController(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ActionResult Index()
        {
            return View(_projectRepository.All());
        }
    }
}