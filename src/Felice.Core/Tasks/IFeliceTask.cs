namespace Felice.Core.Tasks
{
    public interface IFeliceTask
    {
        string HelpText
        {
            get;
        }

        string Command
        {
            get;
        }

        void Execute(params string[] args);
    }
}