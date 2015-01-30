using MediatR;
using NUnit.Framework;
using Web.Commands;

namespace Web.Tests
{
    using System.Data.SqlServerCe;
    using System.IO;
    using System.Web;
    using Felice.Core;
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

            if (File.Exists("4sale_test.sdf")) File.Delete("4sale_test.sdf");

            new SqlCeEngine(AppSettings.ConnectionString).CreateDatabase();

            Database.MigrateToLastVersion();
        }

        [Test]
        public void Should_handle_command()
        {
            _mediator.Send(new EditProductCommand()
            {
                Name = "Notebook Acer Aspiron",
                Price = "290,90",
                Image = Substitute.For<HttpPostedFileBase>()
            });
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void Should_throw_exception_if_command_is_invalid()
        {           
            _mediator.Send(new EditProductCommand());
        }
    }
}
