namespace Demo.Controllers
{
    using System.Web.Mvc;
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