using MediatR;
using NUnit.Framework;
using Should;
using Web.Commands;

namespace Web.Tests
{
    using System.Web;
    using Felice.Data;
    using FluentValidation;
    using NSubstitute;

    [TestFixture]
    public class EditProductHandlerTest
    {
        private IMediator _mediator;

        [SetUp]
        public void Setup()
        {
            DependencyConfig.RegisterDependencies();
            _mediator = DependencyConfig.Container.GetInstance<IMediator>();

            Database.MigrateToLastVersion();
        }

        [Test]
        public void Should_handle_command()
        {
            var product = _mediator.Send(new EditProductCommand()
            {
                Name = "Notebook Acer Aspiron",
                Price = "290,90",
                Image = Substitute.For<HttpPostedFileBase>()
            });

            product.Name.ShouldEqual("Notebook Acer Aspiron");
            product.Price.ShouldEqual(290.9m);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void Should_throw_exception_if_command_is_invalid()
        {           
            _mediator.Send(new EditProductCommand());
        }
    }
}
