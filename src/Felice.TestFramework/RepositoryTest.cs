namespace Felice.TestFramework
{
    using Core.Model;
    using NBehave.Spec.NUnit;
    using NUnit.Framework;

    public abstract class RepositoryTest<TEntity, TRepository> : IntegratedTest
        where TEntity : Entity
        where TRepository : IRepository<TEntity>, new()
    {
        protected TRepository repository = new TRepository();

        [Test]
        public void Should_get_by_id()
        {
            var one = this.CreateEntity().Persist();
            this.CreateEntity().Persist();
            this.CreateEntity().Persist();

            this.repository.ById(one.Id).ShouldEqual(one);
        }

        [Test]
        public void Should_get_all()
        {
            var one = this.CreateEntity().Persist();
            var two = this.CreateEntity().Persist();
            var three = this.CreateEntity().Persist();

            var compare = this.repository.All();

            compare.ShouldContain(one);
            compare.ShouldContain(two);
            compare.ShouldContain(three);
        }

        [Test]
        public void Should_save_one()
        {
            var one = this.CreateEntity();
            this.repository.Save(one);

            this.RecreateSession();

            this.repository.ById(one.Id).ShouldEqual(one);
        }

        [Test]
        public void Should_delete_one()
        {
            var one = this.CreateEntity().Persist();
            var two = this.CreateEntity().Persist();
            var three = this.CreateEntity().Persist();

            this.repository.Delete(one);

            this.RecreateSession();

            var compare = this.repository.All();
            compare.Length.ShouldEqual(2);
            compare.ShouldContain(two);
            compare.ShouldContain(three);
        }

        [Test]
        public void Should_delete_by_id()
        {
            var one = this.CreateEntity().Persist();
            var two = this.CreateEntity().Persist();
            var three = this.CreateEntity().Persist();

            this.repository.DeleteById(one.Id);

            this.RecreateSession();

            var compare = this.repository.All();
            compare.Length.ShouldEqual(2);
            compare.ShouldContain(two);
            compare.ShouldContain(three);
        }

        public abstract TEntity CreateEntity();
    }
}
