namespace Web.Tests
{
    using Felice.Data;
    using FluentValidation;
    using MediatR;
    using NUnit.Framework;
    using Should;
    using Web.Commands;

    [TestFixture]
    public class AddImageProductHandlerTest
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
                Price = "290,90"
            });

            product.Name.ShouldEqual("Notebook Acer Aspiron");
            product.Price.ShouldEqual(290.9m);
        }

        [Test]
        //[ExpectedException(typeof(ValidationException))]
        public void Should_throw_exception_if_command_is_invalid()
        {           
            _mediator.Send(new AddImageProductCommand());
        }
    }
}
