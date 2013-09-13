namespace WebDemo.Controllers
{
    using System.Web.Mvc;
    using Felice.Core;
    using Felice.Mvc;
    using Forms;
    using Models;
    using Repositories;

    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult Index()
        {
            return View(this.productRepository.All());
        }

        public ActionResult New()
        {
            return View("Edit", new EditProductForm());
        }

        [HttpPost]
        public ActionResult Edit(EditProductForm form)
        {
            return this.Handle(form)
                .With(x => this.productRepository.Save(new Product()
                {
                    Name = form.Name,
                    Price = form.Price.ToDecimal2()
                }))
                .OnFailure(x => View("Edit", form))
                .OnSuccess(x => RedirectToAction("Index"), "Product was saved");
        }
    }
}