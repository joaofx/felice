namespace Demo.Models
{
    using Felice.Core.Model;

    public class Project : Entity
    {
        public virtual string Name
        {
            get;
            set;
        }
    }
}