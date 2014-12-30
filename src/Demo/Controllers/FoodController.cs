using System.Web.Mvc;

namespace Demo.Controllers
{
    using System;
    using AutoMapper;
    using Felice.Mvc;
    using Forms;
    using Models;
    using Repositories;

    public class FoodController : Controller
    {
        private readonly FoodRepository _foodRepository;

        public FoodController(FoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public ActionResult Index()
        {
            return View(_foodRepository.All());
        }

        public ActionResult New()
        {
            return View("Edit", new EditFoodForm());
        }

        public ActionResult Edit(long id)
        {
            var entity = _foodRepository.ById(id);
            return View("Edit", new EditFoodForm()
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Calories = entity.Calories.ToString(),
                Carbs = entity.Carbs.ToString(),
                Fats = entity.Fats.ToString(),
                Proteins = entity.Proteins.ToString()
            });
        }

        [HttpPost]
        public ActionResult Save(EditFoodForm form)
        {
            return this.Handle(form)
                .With(x =>
                {
                    var food = Mapper.Map<Food>(form);
                    _foodRepository.Save(food);

                    ////new Food
                    ////{
                    ////    Name = form.Name,
                    ////    Calories = Convert.ToDecimal(form.Calories),
                    ////    Proteins = Convert.ToDecimal(form.Proteins),
                    ////    Carbs = Convert.ToDecimal(form.Carbs),
                    ////    Fats = Convert.ToDecimal(form.Fats),
                    ////    Id = Convert.ToInt64(form.Id)
                    ////}
                })
                .OnFailure(x => View("Edit", form))
                .OnSuccess(x => RedirectToAction("Index"), "Food {0} created", form.Name);
        }
    }
}