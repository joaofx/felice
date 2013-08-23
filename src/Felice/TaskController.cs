namespace Felice
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Logs;
    using Core.Tasks;

    public class TaskController
    {
        private readonly List<IFeliceTask> tasks;
        private readonly IFeliceTask helpTask;

        public TaskController(IFeliceTask helpTask, params IFeliceTask[] tarefas)
        {
            this.tasks = tarefas.Where(x => x.GetType() != typeof(HelpTask)).ToList();
            this.helpTask = helpTask;
            this.tasks.Add(helpTask);
        }

        public static bool Match(string command, string args)
        {
            var commandArray = command.Split(' ');
            var argsArray = args.Split(' ');

            if (commandArray.Length > argsArray.Length)
            {
                return false;
            }

            return commandArray.Where((t, x) => t != argsArray[x]).Any() == false;
        }

        public void Execute(params string[] args)
        {
            var argsText = args.Join(" ");
            var task = this.GetTask(argsText);

            Log.App.DebugFormat("Executing {0}", argsText);

            if (task != null)
            {
                Log.App.DebugFormat("Task {0}", task.GetType().FullName);
                task.Execute(args);
            }
            else
            {
                Log.App.DebugFormat("Task was not found. Showing help");
                this.helpTask.Execute("help");
            }
        }

        private IFeliceTask GetTask(string textoArgumentos)
        {
            return this.tasks.FirstOrDefault(tarefa => Match(tarefa.Command, textoArgumentos));
        }
    }
}
