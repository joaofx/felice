namespace Demo.Tests
{
    using AutoMapper;
    using Demo.Boot;
    using Forms;
    using Models;
    using NUnit.Framework;
    using Should;

    [TestFixture]
    public class AutoMapperBootTest
    {
        [SetUp]
        public void SetupFixture()
        {
            new AutoMapperBoot().Execute();            
        }

        [Test]
        public void Should_validate_auto_mapper_configuration()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Just_check_if_model_to_form_is_working()
        {
            var food = new Food()
            {
                Name = "Banana",
                Calories = 109.9m,
                Carbs = 12.34m,
                Fats = 56.78m,
                Proteins = 90.99m
            };

            var form = Mapper.Map<EditFoodForm>(food);

            form.Name.ShouldEqual("Banana");
            form.Calories.ShouldEqual("109,9");
            form.Carbs.ShouldEqual("12,34");
            form.Fats.ShouldEqual("56,78");
            form.Proteins.ShouldEqual("90,99");
        }

        [Test]
        public void Just_check_if_form_to_model_is_working()
        {
            var form = new EditFoodForm()
            {
                Name = "Banana",
                Calories = "109,90",
                Carbs = "12,34",
                Fats = "56,78",
                Proteins = "90,99"
            };

            var model = Mapper.Map<Food>(form);

            model.Name.ShouldEqual("Banana");
            model.Calories.ShouldEqual(109.90m);
            model.Carbs.ShouldEqual(12.34m);
            model.Fats.ShouldEqual(56.78m);
            model.Proteins.ShouldEqual(90.99m);
        }
    }
}
