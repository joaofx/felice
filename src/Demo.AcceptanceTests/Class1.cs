namespace Demo.AcceptanceTests
{
    using System;
    using Controllers;
    using Forms;
    using NUnit.Framework;
    using SpecsFor.Mvc;

    [TestFixture]
    public class FoodTest
    {
        [Test]
        public void Should_create_food()
        {
            var app = new MvcWebApp();

            app.NavigateTo<FoodController>(c => c.Index());

            app.FindLinkTo<FoodController>(x => x.New()).Click();

            app.FindFormFor<EditFoodForm>()
                .Field(f => f.Name).SetValueTo("Rice milk")
                .Submit();

            //assert
            app.AllText().Contains("saved");
        }
    }
}

