
namespace Demo.Controllers
{
    using System.Web.Mvc;
    using Forms;
    using Felice.Mvc;
    using Models;
    using Repositories;

    public class ProjectController : Controller
    {
        private readonly ProjectRepository _projectRepository;

        public ProjectController(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ActionResult Index()
        {
            return View(_projectRepository.All());
        }

        public ActionResult New()
        {
            return View("Edit", new EditProjectForm());
        }

        [HttpPost]
        public ActionResult Save(EditProjectForm form)
        {
            return this.Handle(form)
                .With(x => _projectRepository.Save(new Project { Name = form.Name }))
                .OnFailure(x => View("Edit", form))
                .OnSuccess(x => RedirectToAction("Index"), "Project {0} was saved", form.Name);
        }
    }
}