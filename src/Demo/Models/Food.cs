namespace Demo.Models
{
    using Felice.Core.Model;

    public class Food : Entity
    {
        public virtual string Name { get; set; }
        public virtual decimal Calories { get; set; }
        public virtual decimal Fats { get; set; }
        public virtual decimal Carbs { get; set; }
        public virtual decimal Proteins { get; set; }
    }
}