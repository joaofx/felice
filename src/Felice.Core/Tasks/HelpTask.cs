namespace Felice.Core.Tasks
{
    using System;
    using System.Linq;
    using System.Text;
    using Logs;

    public class HelpTask : IFeliceTask
    {
        public string HelpText
        {
            get
            {
                return "Help";
            }
        }

        public string Command
        {
            get
            {
                return "help";
            }
        }

        public void Execute(params string[] args)
        {
            const string Help = @"Nails {0}

How to use:
    nails [task_name] [task args]

Tarefas:

{1}
";
            var helpText = new StringBuilder();
            ////var tasks = Dependency.GetAll<IFeliceTask>().OrderBy(x => x.Command);

            ////foreach (var tarefa in tasks)
            ////{
            ////    helpText.Append("   ");
            ////    helpText.Append(tarefa.Command);
            ////    helpText.Append(Environment.NewLine);
            ////    helpText.Append("       ");
            ////    helpText.Append(tarefa.HelpText);
            ////    helpText.Append(Environment.NewLine);
            ////    helpText.Append(Environment.NewLine);
            ////}

            ////Log.App.Info(string.Format(Help, FeliceCore.Version, helpText));
        }
    }
}