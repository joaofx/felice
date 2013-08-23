namespace Felice.Core.Tasks
{
    using Data;

    public class DatabaseUpdateTask : IFeliceTask
    {
        public string HelpText
        {
            get
            {
                return "Update database schema";
            }
        }

        public string Command
        {
            get
            {
                return "database update";
            }
        }

        public void Execute(params string[] args)
        {
            Database.Initialize();
            Database.UpdateSchema();
        }
    }
}

