using System.Web.Mvc;

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
            return View(_mediator.Send(new ProductQuery()));
        }

        public ActionResult New()
        {
            return View("Edit", new EditProductCommand());
        }

        [HttpPost]
        public ActionResult Save(EditProductCommand command)
        {
            /// https://github.com/jbogard/MediatR/issues/11
            /// http://lostechies.com/jimmybogard/2014/09/09/tackling-cross-cutting-concerns-with-a-mediator-pipeline/
            /// http://lostechies.com/jimmybogard/2013/12/19/put-your-controllers-on-a-diet-posts-and-commands/
            
            _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}