namespace Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using Commands;
    using Felice.Mvc;
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
            return View(_mediator.Send(new ShowProductQuery {Id = id}));
        }

        public ActionResult New()
        {
            return View("Edit", new EditProductCommand());
        }

        public ActionResult AddImage()
        {
            return View("Edit", new AddImageProductCommand());
        }

        [HttpPost]
        public ActionResult Save(EditProductCommand command)
        {
            try
            {
                var product = _mediator.Send(command);
                this.Success(string.Format("Food {0} created", command.Name));

                return RedirectToAction("Show", "Product", new {product.Id});
            }
            catch (Exception)
            {
                return View("Edit", command);
            }
        }
    }
}