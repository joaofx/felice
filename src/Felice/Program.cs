namespace Felice
{
    using Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            FeliceCore.Initialize();
            new FeliceTasks().Execute(args);
        }
    }
}
