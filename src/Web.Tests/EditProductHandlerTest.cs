using MediatR;
using NUnit.Framework;
using StructureMap;
using Web.Commands;
using Web.Queries;

namespace Web.Tests
{
    [TestFixture]
    public class EditProductHandlerTest
    {
        private IMediator _mediator;

        [SetUp]
        public void Setup()
        {
            DependencyConfig.RegisterDependencies();
            _mediator = DependencyConfig.Container.GetInstance<IMediator>();
        }

        [Test]
        public void Should_edit_product()
        {           
            var product = _mediator.Send(new EditProductCommand
            {
                Price = "259,99"
            });
        }
    }
}
