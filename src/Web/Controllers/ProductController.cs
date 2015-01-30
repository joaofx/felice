using System.Web.Mvc;
using Felice.Mvc;

namespace Web.Controllers
{
    using Commands;
    using MediatR;
    using Queries;

    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View(_mediator.Send(new ListProductQuery()));
        }

        public ActionResult Show(long id)
        {
            return View(_mediator.Send(new ShowProductQuery { Id = id }));
        }

        public ActionResult New()
        {
            return View("Edit", new EditProductCommand());
        }

        [HttpPost]
        public ActionResult Save(EditProductCommand command)
        {
            return this.Handle(command)
                .With(x => _mediator.Send(command))
                .OnFailure(x => View("Edit", command))
                .OnSuccess(x => RedirectToAction("Index"), "Food {0} created", command.Name);
        }
    }
}