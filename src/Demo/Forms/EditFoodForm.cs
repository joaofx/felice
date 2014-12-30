namespace Demo.Forms
{
    using Boot;
    using Models;

    public class EditFoodForm : IMapFrom<Food>, IMapTo<Food>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Calories { get; set; }

        /// TODO: MacroNutriente class
        public string Fats { get; set; }
        public string Carbs { get; set; }
        public string Proteins { get; set; }
    }
}