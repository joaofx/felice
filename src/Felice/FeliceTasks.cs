namespace Felice
{
    using System;
    using System.Linq;
    using Core;
    using Core.Logs;
    using Core.Tasks;

    public class FeliceTasks
    {
        public void Execute(string[] args)
        {
            var tarefas = Dependency.GetAll<IFeliceTask>().ToArray();
            var controller = new TaskController(new HelpTask(), tarefas);

            try
            {
                controller.Execute(args);
            }
            catch (Exception exception)
            {
                Log.App.ErrorFormat(exception, "Was not possible execute {0}", args.Join(" "));
            }
        }
    }
}